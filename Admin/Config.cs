using MySql.Data.MySqlClient;
using System;

namespace espaceNetSAV.Admin
{
    class Config
    {
        private Database databaseObject;
        public int ID { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Config()
        {
            this.databaseObject = new Database();
            ID = 0;
            Host = "localhost";
            Username = "root";
            Password = "";
        }
        public Config(int id, string host, string username, string password)
        {
            this.databaseObject = new Database();
            this.ID = id;
            this.Host = host;
            this.Username = username;
            this.Password = password;
        }

        public Config GetConfiguration(int id)
        {
            try
            {
                string query = "SELECT * FROM configuration WHERE id = @id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader myReade = myCommand.ExecuteReader())
                    {
                        if (myReade.HasRows)
                        {
                            while (myReade.Read())
                            {
                                this.ID = Convert.ToInt32(myReade["id"]);
                                this.Host = myReade["host"].ToString();
                                this.Username = myReade["username"].ToString();
                                this.Password = myReade["password"].ToString();
                            }
                        }
                    }
                }
                return this;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }
        
    }
}
