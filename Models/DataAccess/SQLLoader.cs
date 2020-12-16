using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Requests;

namespace DataAccess
{
	public class SQLLoader
    {
        private string _connectionString;
        public SQLLoader(RequestOpen connectionString)
        {
            _connectionString = connectionString.GetCommand();
        }

        public DataSet Request(RequestTask CommandText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText.GetCommand(), connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

    }
}
