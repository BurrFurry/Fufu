﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Корчуганов
{
    class DB
    {
        MySqlConnection Connection = new MySqlConnection
            ("server=localhost;port=3306;username=root;password=12345;database=mydb");

        public void openConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();

        }
        public void CloseConnection()

        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }

    }
}

   