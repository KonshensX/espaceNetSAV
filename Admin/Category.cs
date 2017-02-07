using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class Category
    {
        Database databaseObject;
        public int ID;
        public string Name { get; set; }


        public Category() { this.ID = this.GetLastID() + 1; ; this.databaseObject = new Database(); }

        public Category(string catName)
        {
            this.databaseObject = new Database();
            this.ID = this.GetLastID() + 1;
            this.Name = catName;
        }


        private int GetLastID()
        {
            try
            {
                string query = "SELECT MAX(id) FROM category";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    MySqlDataReader reader = myCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader[0] is DBNull)
                            {
                                return 0;
                            }
                            return Convert.ToInt32(reader[0]);
                        }
                    }
                    reader.Close();
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        internal void saveToDatabase()
        {
            string query = "INSERT INTO category (`name`) VALUES (@name)";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
        }
    }
}
