using System.Text.Json;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class ClothesWearingRepository : IClothesWearingRepository
    {
        private readonly string _dir;
        private static readonly object _lock = new();
        private static readonly JsonSerializerOptions _json = new() { WriteIndented = true };

        public ClothesWearingRepository(IWebHostEnvironment env, IConfiguration config)
        {
            var dataPath = config["ClothesWearings:DataPath"] ?? "organizing/trackings/clothes-wearings";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _dir = Path.Combine(documentsPath, dataPath, env.EnvironmentName.ToLower());
            Directory.CreateDirectory(_dir);
        }

        private string FilePathForDate(DateOnly date)
        {
            var dir = Path.Combine(_dir, $"{date:yyyy}", $"{date:MM}");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"clothes-wearing-{date:yyyy-MM-dd}.json");
        }

        private List<ClothesWearing> ReadDay(DateOnly date)
        {
            var path = FilePathForDate(date);
            if (!File.Exists(path)) return [];
            return JsonSerializer.Deserialize<List<ClothesWearing>>(File.ReadAllText(path)) ?? [];
        }

        private void WriteDay(DateOnly date, List<ClothesWearing> records) =>
            File.WriteAllText(FilePathForDate(date), JsonSerializer.Serialize(records, _json));

        private List<ClothesWearing> ReadAllDays() =>
            Directory.GetFiles(_dir, "clothes-wearing-????-??-??.json", SearchOption.AllDirectories)
                .SelectMany(path => JsonSerializer.Deserialize<List<ClothesWearing>>(File.ReadAllText(path)) ?? [])
                .ToList();

        private int NextId() =>
            ReadAllDays() is { Count: > 0 } all ? all.Max(r => r.Id) + 1 : 1;

        public Task<ClothesWearing> AddClothesWearingAsync(ClothesWearing clothesWearing)
        {
            lock (_lock)
            {
                var date = DateOnly.FromDateTime(clothesWearing.WearingStart);
                var records = ReadDay(date);
                clothesWearing.Id = NextId();
                records.Add(clothesWearing);
                WriteDay(date, records);
                return Task.FromResult(clothesWearing);
            }
        }

        public Task<List<ClothesWearing>> GetAllClothesWearingsAsync()
        {
            lock (_lock)
            {
                return Task.FromResult(ReadAllDays().OrderByDescending(r => r.WearingStart).ToList());
            }
        }

        public Task<ClothesWearing> GetClothesWearingByIdAsync(int id)
        {
            lock (_lock)
            {
                var record = ReadAllDays().FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"ClothesWearing with id {id} not found.");
                return Task.FromResult(record);
            }
        }

        public Task<ClothesWearing> UpdateClothesWearingAsync(ClothesWearing clothesWearing)
        {
            lock (_lock)
            {
                var existing = ReadAllDays().FirstOrDefault(r => r.Id == clothesWearing.Id)
                    ?? throw new Exception($"ClothesWearing with id {clothesWearing.Id} not found.");

                var oldDate = DateOnly.FromDateTime(existing.WearingStart);
                var oldDayRecords = ReadDay(oldDate);
                oldDayRecords.RemoveAll(r => r.Id == clothesWearing.Id);
                if (oldDayRecords.Count == 0)
                {
                    File.Delete(FilePathForDate(oldDate));
                    CleanEmptyDirs(oldDate);
                }
                else
                    WriteDay(oldDate, oldDayRecords);

                var newDate = DateOnly.FromDateTime(clothesWearing.WearingStart);
                var newDayRecords = ReadDay(newDate);
                newDayRecords.Add(clothesWearing);
                WriteDay(newDate, newDayRecords);

                return Task.FromResult(clothesWearing);
            }
        }

        public Task DeleteClothesWearingAsync(int id)
        {
            lock (_lock)
            {
                var record = ReadAllDays().FirstOrDefault(r => r.Id == id)
                    ?? throw new Exception($"ClothesWearing with id {id} not found.");

                var date = DateOnly.FromDateTime(record.WearingStart);
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
