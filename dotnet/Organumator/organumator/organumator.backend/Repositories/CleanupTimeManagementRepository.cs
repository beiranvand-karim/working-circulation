using System.Text.Json;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class CleanupTimeManagementRepository : ICleanupTimeManagementRepository
    {
        private readonly string _dir;
        private static readonly object _lock = new();
        private static readonly JsonSerializerOptions _json = new() { WriteIndented = true };

        public CleanupTimeManagementRepository(IWebHostEnvironment env)
        {
            _dir = Path.Combine(env.ContentRootPath, "Data", "json", env.EnvironmentName.ToLower());
            Directory.CreateDirectory(_dir);
        }

        private static string WeekOfMonth(DateOnly date) => $"week-{(date.Day - 1) / 7 + 1}";

        private string FilePathForDate(DateOnly date)
        {
            var dir = Path.Combine(_dir, $"{date:yyyy}", $"{date:MM}", WeekOfMonth(date));
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"{date:yyyy-MM-dd}.json");
        }

        private List<CleanupTimeManagement> ReadDay(DateOnly date)
        {
            var path = FilePathForDate(date);
            if (!File.Exists(path)) return [];
            return JsonSerializer.Deserialize<List<CleanupTimeManagement>>(File.ReadAllText(path)) ?? [];
        }

        private void WriteDay(DateOnly date, List<CleanupTimeManagement> records) =>
            File.WriteAllText(FilePathForDate(date), JsonSerializer.Serialize(records, _json));

        private List<CleanupTimeManagement> ReadAllDays() =>
            Directory.GetFiles(_dir, "????-??-??.json", SearchOption.AllDirectories)
                .SelectMany(path => JsonSerializer.Deserialize<List<CleanupTimeManagement>>(File.ReadAllText(path)) ?? [])
                .ToList();

        private int NextId() =>
            ReadAllDays() is { Count: > 0 } all ? all.Max(r => r.Id) + 1 : 1;

        public Task<CleanupTimeManagement> SaveStartAsync(DateTime startedAt)
        {
            lock (_lock)
            {
                var date = DateOnly.FromDateTime(startedAt);
                var records = ReadDay(date);
                var record = new CleanupTimeManagement { Id = NextId(), StartedAt = startedAt };
                records.Add(record);
                WriteDay(date, records);
                return Task.FromResult(record);
            }
        }

        public Task<CleanupTimeManagement> SaveFinishAsync(int id, DateTime finishedAt)
        {
            lock (_lock)
            {
                var all = ReadAllDays();
                var record = all.FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"CleanupTimeManagement with id {id} not found.");
                record.FinishedAt = finishedAt;
                var date = DateOnly.FromDateTime(record.StartedAt);
                var dayRecords = ReadDay(date);
                var target = dayRecords.First(r => r.Id == id);
                target.FinishedAt = finishedAt;
                WriteDay(date, dayRecords);
                return Task.FromResult(target);
            }
        }

        public Task<List<CleanupTimeManagement>> GetAllAsync()
        {
            lock (_lock)
            {
                return Task.FromResult(ReadAllDays().OrderByDescending(r => r.StartedAt).ToList());
            }
        }

        public Task<CleanupTimeManagement> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var record = ReadAllDays().FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"CleanupTimeManagement with id {id} not found.");
                return Task.FromResult(record);
            }
        }

        public Task DeleteAsync(int id)
        {
            lock (_lock)
            {
                var all = ReadAllDays();
                var record = all.FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"CleanupTimeManagement with id {id} not found.");
                var date = DateOnly.FromDateTime(record.StartedAt);
                var dayRecords = ReadDay(date);
                dayRecords.RemoveAll(r => r.Id == id);
                if (dayRecords.Count == 0)
                {
                    File.Delete(FilePathForDate(date));
                    var weekDir = Path.Combine(_dir, $"{date:yyyy}", $"{date:MM}", WeekOfMonth(date));
                    if (Directory.Exists(weekDir) && !Directory.EnumerateFileSystemEntries(weekDir).Any())
                    {
                        Directory.Delete(weekDir);
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
                else
                    WriteDay(date, dayRecords);
                return Task.CompletedTask;
            }
        }
    }
}
