using DirectoryManagement;

string workingDirectory = Environment.GetCommandLineArgs()[1];
string commandToExecute = Environment.GetCommandLineArgs()[2];

DirectoryOperations.OpenDirectoryThroughCommandLine(commandToExecute, workingDirectory);