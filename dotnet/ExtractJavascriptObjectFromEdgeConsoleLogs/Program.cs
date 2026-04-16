namespace ExtractJavascriptObjectFromEdgeConsoleLogs;

class Program
{
    static void Main(string[] args)
    {

        try
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string phraseToFind = Environment.GetCommandLineArgs()[1];

            Console.WriteLine(workingDirectory);
            Console.WriteLine(phraseToFind);

            foreach (string file in Directory.EnumerateFiles(workingDirectory))
            {
                Console.WriteLine(file);

                using var readText = new StreamReader(file);
                var currentLine = readText.ReadLine();
                if (currentLine != null)
                {
                    if (currentLine.Contains(phraseToFind))
                    {
                        Console.WriteLine(currentLine);
                    }
                }
            }  
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
      
    }
}
