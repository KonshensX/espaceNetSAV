using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class Category
    {
        Database databaseObject;
        public int ID;
        public string Name { get; set; }


        public Category() { this.databaseObject = new Database(); this.ID = this.GetLastID() + 1; }

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Saves the current object in the database
        /// </summary>
        internal void saveToDatabase()
        {
            string query = "INSERT INTO category (`name`) VALUES (@name)";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@name", this.Name);
                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Fetch all the categories in the database into a list
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            List<Category> myList = new List<Category>();

            string query = "SELECT * FROM category"; //TODO: Insert the proper query.

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    Category catObject;
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            catObject = new Category();
                            catObject.ID = Convert.ToInt32(myReader[0]);
                            catObject.Name = myReader[1].ToString();

                            myList.Add(catObject);
                        }
                    }
                }
            }

            return myList;
        }
    }
}
