using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Enums;
using FileManager;
using BusinessLogic;
using JsonBuilder;
using System.IO;
using System.Threading;

namespace ModuleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                var buildManager = new BuildManager();
                buildManager.SetConfigPath(Path.Combine(Directory.GetCurrentDirectory(), "Settings.Json"));
                Thread loggerThread = new Thread(new ThreadStart(buildManager.OnStart));
                loggerThread.Start();
            }
            catch(Exception ex)
            {
                using(var file = new StreamWriter(
                    new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "logs.txt"), FileMode.Append)))
                {
                    file.WriteLine(ex.Message);
                }
            }
            while (true) ;
        }
    }

    public partial class BuildManager
    {
        public BuildManager()
        {

        }

        FileWatcherManager fileManager;
        string _targetPath;
        string _configPath;

        public void SetConfigPath(string configPath)
        {
            _configPath = configPath;
        }

        public void OnStart()
        {
            string[] args = { _configPath };
            OnStart(args);
        }

        public void OnStart(string[] args)
        {
            var parser = new ConfigurationManager.ConfigManager<FileProcessMods>();
            parser.MakeParsed(args[0]);
            var sourcePath = parser.SourcetPath;
            _targetPath = parser.TargetPath;
            if (sourcePath == null || _targetPath == null)
                throw new NullReferenceException("Error path");
            var mods = parser.GetMods();

            fileManager = new FileWatcherManager(_targetPath, sourcePath, mods);
            fileManager.OnStart();

            Thread loggerThread = new Thread(new ThreadStart(Load));
            loggerThread.Start();

        }

        private void Load()
        {
            LoaderJson.Load(SQLJsonBuilder("Department", 100).GetDepartments().GetAll(), _targetPath, "Department");
            LoaderJson.Load(SQLJsonBuilder("Employee", 100).GetEmployee().GetAll(), _targetPath, "Employee");
            LoaderJson.Load(SQLJsonBuilder("EmployeeDepartmentHistory", 100).GetEmployeeDepartmentHistory().GetAll(), _targetPath, "EmployeeDepartmentHistory");
            LoaderJson.Load(SQLJsonBuilder("EmployeePayHistory", 100).GetEmployeePayHistory().GetAll(), _targetPath, "EmployeePayHistory");
            LoaderJson.Load(SQLJsonBuilder("JobCandidate", 100).GetJobCandidate().GetAll(), _targetPath, "JobCandidate");
            LoaderJson.Load(SQLJsonBuilder("Shift", 100).GetShift().GetAll(), _targetPath, "Shift");
        }

        public void OnStop()
        {
            fileManager.OnStop();
        }


        public TablesManager SQLJsonBuilder(string tableName, int top)
        {
            var requestParser
                = new RequestParser(new Requests.RequestOpen().DataSource(@".\TASKSQL")
                .InitialCatalog("AdventureWorks2012").IntegratedSecurity(true));
            return requestParser.LoadRequest(
                new Requests.RequestTask().Select().Top(top).From("HumanResources." + tableName).As());
        }
    }
}
