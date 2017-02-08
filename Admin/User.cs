using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    enum Role
    {
        Admin,
        User, 
        Nothing
    }
    class User
    {
        public Database databaseObject;
        public int ID;
        public string Name;
        public string Password;
        public DateTime date;
        public Role role;
        public Category category;

        public User()
        {
            this.databaseObject = new Database();
            this.ID = this.GetLastID() + 1;
            this.Name = "";
            this.Password = "";
            this.date = DateTime.Now;
            this.role = Role.User;
            this.category = new Category();
        }

        public User(string username, string password, Category category)
        {
            this.databaseObject = new Database();
            this.ID = this.GetLastID() + 1;
            this.Name = username;
            this.Password = password;
            this.date = DateTime.Now;
            this.role = Role.User;
            this.category = category;
        }



        /// <summary>
        /// Gets the last user ID in the database
        /// </summary>
        /// <returns></returns>
        private int GetLastID()
        {
            try
            {
                string query = "SELECT MAX(id) FROM users";
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

        
        /// <summary>
        /// Create a user - Persist the user to teh database
        /// </summary>
        /// <returns></returns>
        public int createUser()
        {
            string query = "INSERT INTO `users`( `username`, `password`, `isAdmin`, `createdat`, `cat_id`) VALUES (@username, @password, @isAdmin, @created, @cat_id)";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {

                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@username", this.Name);
                myCommand.Parameters.AddWithValue("@password", this.Password);
                myCommand.Parameters.AddWithValue("@isAdmin", this.GetUserRole(this.role)); //This needs more work 
                myCommand.Parameters.AddWithValue("@created", this.date);
                myCommand.Parameters.AddWithValue("@cat_id", this.category.ID);
                return Convert.ToInt32(myCommand.ExecuteNonQuery());
            }
        }

        //Get a user from the database
          
        //Update user

        //Fetch all users in the database
        /// <summary>
        /// Fetch all the users in the database into a List
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            try
            {
                List<User> myList = new List<User>();
                string query = "SELECT * FROM users";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    MySqlDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        User user = new User();
                        user.ID = Convert.ToInt32(myReader[0]);
                        user.Name = myReader[1].ToString();
                        user.Password = myReader[2].ToString();
                        user.category.getCategory(Convert.ToInt32(myReader[5]));
                        myList.Add(user);
                    }
                }

                return myList;
            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        //Delete a user from the database

        //Check whether the user is admin or not 

        //Get user role
        private int GetUserRole(Role role)
        {
            switch(role)
            {
                case Role.Admin:
                    return 1;
                case Role.User:
                    return 0;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// This will get the user Role based on the value in the database
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private Role GetUserRole(int role)
        {
            switch (role)
            {
                case 1:
                    return Role.Admin;
                case 0 :
                    return Role.Nothing;
                default:
                    return Role.Nothing;
            }
        }

        /// <summary>
        /// Check if the user already exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool UserAlreadyExists(string username)
        {
            string query = "SELECT * FROM users WHERE username like @username";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@username", username);
                MySqlDataReader myReader = myCommand.ExecuteReader();

                return myReader.HasRows;

            }
        }

        /// <summary>
        /// Check user credentials
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="cryptedPassword">The Encrypted password</param>
        /// <returns></returns>

        public bool CheckCredentials(string username, string cryptedPassword)
        {
            string query = "SELECT * FROM users WHERE username like @username AND password LIKE @pwd";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@username", username);
                myCommand.Parameters.AddWithValue("@pwd", cryptedPassword);

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if(myReader.HasRows)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        /// <summary>
        /// This will get the loggeed in user from database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string username, string password)
        {
            string query = "SELECT * FROM users WHERE username like @username AND password like @password";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@username", username);
                myCommand.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            this.ID = Convert.ToInt32(myReader[0]);
                            this.Name = myReader[1].ToString();
                            this.Password = myReader[2].ToString();
                            this.date = Convert.ToDateTime(myReader[4]);
                            this.role = this.GetUserRole(Convert.ToInt32(myReader[3]));
                        } 
                    }
                }
            }


            return this;
        }

        public bool isAdmin()
        {
            string query = "SELECT isAdmin FROM users WHERE username like @username";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@username", this.Name);
                using (MySqlDataReader myReader = myCommand.ExecuteReader()) 
                {
                    if(myReader.HasRows)
                    {
                        while (myReader.Read()) 
                        {
                            return (Convert.ToInt32(myReader[0]) == 1) ? true : false;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
