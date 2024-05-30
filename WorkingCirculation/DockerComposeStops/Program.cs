using System.Diagnostics;

void RunCommand(string commandToExecute) {
    Process process = new Process();
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = $"/c {commandToExecute}";
    process.StartInfo.RedirectStandardOutput= true;
    process.Start();
    process.WaitForExit();
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
}

string commandToExecute = Environment.GetCommandLineArgs()[1];

RunCommand(commandToExecute);