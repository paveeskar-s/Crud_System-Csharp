using System;
using MySql.Data.MySqlClient;

namespace crud_system
{
    internal class Mysqlcommand
    {
        private object query;
        private Mysqlconnection myconn2;
        private string sql;
        private MySqlConnection connection;

        public Mysqlcommand(object query, Mysqlconnection myconn2)
        {
            this.query = query;
            this.myconn2 = myconn2;
        }

        public Mysqlcommand(string sql, MySqlConnection connection)
        {
            this.sql = sql;
            this.connection = connection;
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public static implicit operator MySqlCommand(Mysqlcommand v)
        {
            throw new NotImplementedException();
        }
    }
}