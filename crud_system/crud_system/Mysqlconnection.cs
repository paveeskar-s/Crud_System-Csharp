using System;
using MySql.Data.MySqlClient;

namespace crud_system
{
    internal class Mysqlconnection
    {
        private string crud;

        public Mysqlconnection(string crud)
        {
            this.crud = crud;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        public static implicit operator MySqlConnection(Mysqlconnection v)
        {
            throw new NotImplementedException();
        }
    }
}