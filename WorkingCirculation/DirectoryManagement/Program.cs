using System.Diagnostics;

void RunCommand(string commandToExecute, string workingDirectory) {
    Process process = new Process();
    process.StartInfo.WorkingDirectory = workingDirectory;
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = $"/c {commandToExecute}";
    process.StartInfo.RedirectStandardOutput= true;
    process.Start();
    process.WaitForExit();
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
}

string workingDirectory = Environment.GetCommandLineArgs()[1];
string commandToExecute = Environment.GetCommandLineArgs()[2];

RunCommand(commandToExecute, workingDirectory);