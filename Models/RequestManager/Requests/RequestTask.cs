using System;
using System.Collections.Generic;
using System.Text;

namespace Requests
{
    public class RequestTask : IRequest
    {
        private string sqlCommand = "";
        private string table;

        public RequestTask Select()
        {
            if (sqlCommand != String.Empty)
                sqlCommand += " ";
            sqlCommand += "SELECT";
            return this;
        }

        public RequestTask Top(int top)
        {
            if (sqlCommand != String.Empty)
                sqlCommand += " ";
            sqlCommand += "TOP(" + top.ToString() + ") n.*";
            return this;
        }

        public RequestTask As()
        {
            if (sqlCommand != String.Empty)
                sqlCommand += " ";
            sqlCommand += "AS n";
            return this;
        }

        public RequestTask From(string fulltableName)
        {
            if (sqlCommand != String.Empty)
                sqlCommand += " ";
            sqlCommand += "FROM " + fulltableName;
            table = fulltableName;
            return this;
        }

        public string GetTableName()
        {
            return table;
        }
        public string GetCommand()
        {
            return sqlCommand;
        }
    }
}
