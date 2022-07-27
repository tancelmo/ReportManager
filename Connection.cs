﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    internal class Connection
    {
        OdbcConnection connection = new OdbcConnection();

        public Connection(string Db)
        {
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Db + ";Persist Security Info=True";
            connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + Db + ";";
        }

        public OdbcConnection Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

        public void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
