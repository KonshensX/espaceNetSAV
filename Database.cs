using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    class Database
    {
        private const int _MAX_POOL_SIZE = 100;
        private MySqlConnection connection;
        private string server;
        private string database;
        private int port;
        private string uid;
        private string password;

        public Database()
        {
            try
            {
                this.server = "192.168.1.2";
                this.port = 3306;
                this.database = "espaceNetSav";
                this.uid = "espacenet";
                this.password = "123456";
                string connectionString = "Server=" + server + ";Port= " + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";Max Pool Size= " + _MAX_POOL_SIZE;

                this.connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        #region Methodes
        //open the connection
        public bool openConnection()
        {
            try
            {
                if (!(this.connection.State == System.Data.ConnectionState.Open))
                {
                    this.connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server, Contact admin");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid credentials, please try again");
                        break;

                }
                return false;
            }
        }

        //Close the connection

        public bool closeConnection()
        {
            try
            {
                if (!(this.connection.State == System.Data.ConnectionState.Closed))
                {
                    this.connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public MySqlConnection getConnection()
        {
            return this.connection;
        }
        #endregion

        #region Query Methodes
        
        #endregion
    }
}
