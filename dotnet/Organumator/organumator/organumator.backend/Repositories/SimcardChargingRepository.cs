using System.Text.Json;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class SimcardChargingRepository : ISimcardChargingRepository
    {
        private readonly string _dir;
        private static readonly object _lock = new();
        private static readonly JsonSerializerOptions _json = new() { WriteIndented = true };

        public SimcardChargingRepository(IWebHostEnvironment env, IConfiguration config)
        {
            var dataPath = config["SimcardChargings:DataPath"] ?? "organizing/simcard-chargings";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _dir = Path.Combine(documentsPath, dataPath, env.EnvironmentName.ToLower());
            Directory.CreateDirectory(_dir);
        }

        private string FilePathForDate(DateOnly date)
        {
            var dir = Path.Combine(_dir, $"{date:yyyy}", $"{date:MM}");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"simcard-charging-{date:yyyy-MM-dd}.json");
        }

        private List<SimcardCharging> ReadDay(DateOnly date)
        {
            var path = FilePathForDate(date);
            if (!File.Exists(path)) return [];
            return JsonSerializer.Deserialize<List<SimcardCharging>>(File.ReadAllText(path)) ?? [];
        }

        private void WriteDay(DateOnly date, List<SimcardCharging> records) =>
            File.WriteAllText(FilePathForDate(date), JsonSerializer.Serialize(records, _json));

        private List<SimcardCharging> ReadAllDays() =>
            Directory.GetFiles(_dir, "simcard-charging-????-??-??.json", SearchOption.AllDirectories)
                .SelectMany(path => JsonSerializer.Deserialize<List<SimcardCharging>>(File.ReadAllText(path)) ?? [])
                .ToList();

        private int NextId() =>
            ReadAllDays() is { Count: > 0 } all ? all.Max(r => r.Id) + 1 : 1;

        public Task<SimcardCharging> SaveAsync(DateTime chargedAt)
        {
            lock (_lock)
            {
                var date = DateOnly.FromDateTime(chargedAt);
                var records = ReadDay(date);
                var record = new SimcardCharging { Id = NextId(), ChargedAt = chargedAt };
                records.Add(record);
                WriteDay(date, records);
                return Task.FromResult(record);
            }
        }

        public Task<PagedResult<SimcardCharging>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            lock (_lock)
            {
                var all = ReadAllDays().OrderByDescending(r => r.ChargedAt).ToList();
                var items = all.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                return Task.FromResult(new PagedResult<SimcardCharging>
                {
                    Items = items,
                    TotalCount = all.Count,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
            }
        }

        public Task<SimcardCharging> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var record = ReadAllDays().FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"SimcardCharging with id {id} not found.");
                return Task.FromResult(record);
            }
        }

public Task DeleteAsync(int id)
        {
            lock (_lock)
            {
                var all = ReadAllDays();
                var record = all.FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"SimcardCharging with id {id} not found.");
                var date = DateOnly.FromDateTime(record.ChargedAt);
                var dayRecords = ReadDay(date);
                dayRecords.RemoveAll(r => r.Id == id);
                if (dayRecords.Count == 0)
                {
                    File.Delete(FilePathForDate(date));
                    CleanEmptyDirs(date);
                }
                else
                    WriteDay(date, dayRecords);
                return Task.CompletedTask;
            }
        }

private void CleanEmptyDirs(DateOnly date)
        {
            var monthDir = Path.Combine(_dir, $"{date:yyyy}", $"{date:MM}");
            if (Directory.Exists(monthDir) && !Directory.EnumerateFileSystemEntries(monthDir).Any())
            {
                Directory.Delete(monthDir);
                var yearDir = Path.Combine(_dir, $"{date:yyyy}");
                if (Directory.Exists(yearDir) && !Directory.EnumerateFileSystemEntries(yearDir).Any())
                    Directory.Delete(yearDir);
            }
        }
    }
}
