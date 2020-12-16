using System.Threading;
using System.Collections.Generic;
using FileManager.Enums;

namespace FileManager
{
    public class FileWatcherManager
    {
        private Logger _logger;
        private string _sourcePath;
        private string _targetPath;
        Dictionary<FileProcessMods, string> mods;

        public FileWatcherManager(string targetPath, string sourcePath, Dictionary<FileProcessMods, string> mods)
        {
            _targetPath = targetPath;
            _sourcePath = sourcePath;
            this.mods = mods;
        }

        public void OnStart()
        {
            _logger = new Logger(_targetPath, _sourcePath, mods);
            Thread loggerThread = new Thread(new ThreadStart(_logger.Start));
            loggerThread.Start();
        }

        public void OnStop()
        {
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}