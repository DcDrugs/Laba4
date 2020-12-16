using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FileManager.Enums;
using System.Threading;
using Scramblers;

namespace FileManager
{
    delegate void ProcessHandler(string directoryName);
    delegate void AddDirectoryNameHandler(string name);
    class Logger
    {
        private FileSystemWatcher _watcher;
        private static CryptoManager _crypto = new CryptoManager();
        private string _sourcePath;
        private bool _enabled = true;
        private static Options.ArchiveCryptManager _manager = new Options.ArchiveCryptManager(ref _crypto);
        private event ProcessHandler _Processed;
        private static readonly Dictionary<FileProcessMods, AddDirectoryNameHandler> _addDirectoryName
            = new Dictionary<FileProcessMods, AddDirectoryNameHandler>
            {
                { FileProcessMods.Archive, _manager.archivator.SetArchiveName},
                { FileProcessMods.Dearchive,  _manager.archivator.SetDearchiveName},
                { FileProcessMods.Encrypt,  _manager.cryptor.SetEncryptName },
                { FileProcessMods.ArchiveAndEcrypt,  _manager.archiveCrypt.SetArchiveAndEcryptName },
                { FileProcessMods.Decrypt, _manager.cryptor.SetDecryptName }
            };
        private static readonly Dictionary<FileProcessMods, ProcessHandler> _operation
            = new Dictionary<FileProcessMods, ProcessHandler>
            {
                { FileProcessMods.Archive,  _manager.ProcessCompress},
                { FileProcessMods.Dearchive,  _manager.ProcessDecompress},
                { FileProcessMods.Encrypt,  _manager.ProcessEncrypt},
                { FileProcessMods.Decrypt, _manager.ProcessDecrypt},
                { FileProcessMods.ArchiveAndEcrypt,  _manager.ProcessArchiveAndEcrypt}
            };

        public Logger(string targetPath, string sourcePath, Dictionary<FileProcessMods, string> mods)
        {
            _sourcePath = sourcePath;
            _watcher = new FileSystemWatcher(targetPath);
            _watcher.Created += WatcherCreated;
            _manager.path.MakePath(targetPath, sourcePath);
            foreach (var mod in mods)
            {
                _Processed += _operation[mod.Key];
                _addDirectoryName[mod.Key](mod.Value);
            }
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while (_enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }
        private void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                var name = new Options.FileOption(_Processed, e.Name);
                Thread loggerThread = new Thread(new ThreadStart(name.Process));
                loggerThread.Start();
            }
            catch (Exception ex)
            {
                using (var file = new FileStream(Path.Combine(_sourcePath, e.Name + "_" + DateTime.Now + ".txt"), FileMode.Create))
                {
                    file.Write(Encoding.ASCII.GetBytes(ex.Message), 0, ex.Message.Length);
                }
            }
        }
    }
}
