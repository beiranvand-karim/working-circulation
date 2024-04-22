using DirectoryManagement;

string choice = "2";
string workingDirectory = Environment.GetCommandLineArgs()[1];

if(choice == "1") 
{
    string commandToExecute = Environment.GetCommandLineArgs()[2];
    DirectoryOperations.OpenDirectoryThroughCommandLine(commandToExecute, workingDirectory);
}

if(choice == "2") 
{
    DirectoryOperations.OpenDirectoryThroughExplorer(workingDirectory);
}
