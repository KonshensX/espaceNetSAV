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

        /// <summary>
        /// This will get the category from the database
        /// </summary>
        /// <param name="CAT_ID">The ID of the Category</param>
        /// <returns></returns>
        public Category getCategory(int CAT_ID)
        {
            string query = "SELECT * FROM category WHERE id = @id";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                myCommand.Parameters.AddWithValue("@id", CAT_ID);
                this.databaseObject.openConnection();
                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        this.ID = Convert.ToInt32(myReader[0]);
                        this.Name = myReader[1].ToString();
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// This will get the ID of the category based on the name given
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetIDBasedOnName(string name)
        {
            string query = "SELECT id FROM category WHERE name like @name";   

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            return Convert.ToInt32(myReader[0]);
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// This will fetch the category from the database into an object 
        /// </summary>
        /// <param name="name">ID of the category</param>
        public Category FetchCategoryBasedOnName(string name)
        {
            string query = "SELECT * FROM category WHERE name like @name";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            this.ID = Convert.ToInt32(myReader[0]);
                            this.Name = myReader[1].ToString();
                        }
                    }
                }
            }

            return this;
        }
    }
}
