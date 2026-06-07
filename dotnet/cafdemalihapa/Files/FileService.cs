namespace cafdemalihapa.Files
{
    public static class FileService
    {
        public static void CreateNumberedFiles(string path)
        {
            var dashLine = new string('-', 40);
            var lines = Enumerable.Range(0, 20)
                .SelectMany<int, string>(index => index == 0
                    ? [dashLine]
                    : ["", "", "", dashLine])
                .ToList();

            foreach (var number in Enumerable.Range(1, 10))
            {
                var filePath = Path.Combine(path, number.ToString("D3"));
                File.WriteAllLines(filePath, lines);
            }
        }
    }
}
