using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies
{
    public abstract class DirectoryOpenStrategy(ILogger logger) : IDirectoryOpenStrategy
    {
        protected abstract string FileName { get; }

        public abstract bool CanHandle();

        protected virtual string TransformPath(string path) => path;

        public void Open(string path)
        {
            var argument = TransformPath(path);

            logger.LogInformation("path: {path}", path);
            logger.LogInformation("argument: {argument}", argument);

            using Process myProcess = new();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = FileName;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.ArgumentList.Add(argument);

            myProcess.Start();

            logger.LogInformation("myProcess: {myProcess}", myProcess.Id);
        }
    }
}
