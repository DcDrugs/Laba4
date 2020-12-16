using System;
using System.Collections.Generic;
using System.Text;

namespace Requests
{
    public class RequestOpen : IRequest
    {
        private string sqlCommand = "";

        public void Verification(string command)
        {
            var tasks = command.Split('=');
            if(tasks.Length < 3 || tasks[0] != "Data Source" 
                || tasks[1].Split(';')[1] != "Initial Catalog")
                throw new Exception("FormatException");
            sqlCommand = command;
        }

        public RequestOpen DataSource(string source)
        {
            if (sqlCommand != String.Empty)
                sqlCommand += ";";
            sqlCommand += "Data Source=" + source;
            return this;
        }

        public RequestOpen InitialCatalog(string source)
        {
            if (sqlCommand != String.Empty)
                sqlCommand += ";";
            sqlCommand += "Initial Catalog=" + source;
            return this;
        }

        public RequestOpen IntegratedSecurity(bool source)
        {
            if (sqlCommand != String.Empty)
                sqlCommand += ";";
            sqlCommand += "Integrated Security=" + source.ToString();
            return this;
        }


        public string GetCommand()
        {
            return sqlCommand;
        }
    }
}
