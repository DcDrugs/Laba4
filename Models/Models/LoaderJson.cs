using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonBuilder;
using System.IO;

namespace ModuleConsole
{
    class LoaderJson
    {
        public static void Load<T>(IEnumerable<T> table, string path, string tableName) where T : class
        {
            JsonConfigBuilder jsonConfigBuilder = new JsonConfigBuilder();
            jsonConfigBuilder.LoadTable(table, tableName);
            jsonConfigBuilder.MakeJsonConfig(path, tableName + ".json");
        }
    }
}
