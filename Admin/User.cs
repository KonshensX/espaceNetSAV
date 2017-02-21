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
        public Permissions Permissions { get; set; }

        public User()
        {
            this.databaseObject = new Database();
            this.ID = this.GetLastID() + 1;
            this.Name = "";
            this.Password = "";
            this.date = DateTime.Now;
            this.role = Role.User;
            this.category = new Category();
            this.Permissions = new Permissions();
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
            this.EncryptPassword();
            this.Permissions = new Permissions();

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
                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
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
        /// Create a user - Persist the user to the database
        /// </summary>
        /// <returns></returns>
        public int createUser()
        {
            try
            {
                string query = "INSERT INTO `users`(`id`, `username`, `password`, `isAdmin`, `createdat`, `cat_id`) VALUES (@id, @username, @password, @isAdmin, @created, @cat_id)";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {

                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@id", this.ID);
                    myCommand.Parameters.AddWithValue("@username", this.Name);
                    myCommand.Parameters.AddWithValue("@password", this.Password);
                    myCommand.Parameters.AddWithValue("@isAdmin", this.GetUserRole(this.role)); //This needs more work 
                    myCommand.Parameters.AddWithValue("@created", this.date);
                    myCommand.Parameters.AddWithValue("@cat_id", this.category.ID);
                    this.Permissions.CreateEmptyUserPermissions(this);
                    return Convert.ToInt32(myCommand.ExecuteNonQuery());
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
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
                        user.Permissions.GetUserPermissions(user.ID);
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

        /// <summary>
        /// Delete the current user from the database
        /// </summary>
        public bool Delete()
        {

            try
            {
                string query = "DELETE FROM users WHERE id = @user_id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@user_id", this.ID);

                    return (myCommand.ExecuteNonQuery() == 1) ? true : false;
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

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
            try
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
            finally
            {
                this.databaseObject.closeConnection();
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
            try
            {
                string query = "SELECT * FROM users WHERE username like @username AND password LIKE @pwd";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@pwd", cryptedPassword);

                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            return true;
                        }
                    }

                }

                return false;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// This will get the loggeed in user from database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string username, string password)
        {
            try
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
                                this.category.getCategory(Convert.ToInt32(myReader["cat_id"]));
                                //this.Permissions.GetUserPermissions();
                                this.Permissions.GetUserPermissions(this);
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

        /// <summary>
        /// Checks if the current user as admin or not
        /// </summary>
        /// <returns></returns>
        public bool isAdmin()
        {
            try
            {
                string query = "SELECT isAdmin FROM users WHERE username like @username";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@username", this.Name);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
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
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Save the current object to the database
        /// </summary>
        /// <returns></returns>
        public int saveChanges()
        {
            try
            {
                //This will save the changes made to the object to the database 
                string query = "UPDATE `users` SET `username`=@username,`password`=@password,`cat_id`=@cat_id WHERE `id` = @userID"; //TODO: Fix te query 
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@username", this.Name);
                    myCommand.Parameters.AddWithValue("@password", new CrysptingService().Encrypt(this.Password, Program._KEY));
                    myCommand.Parameters.AddWithValue("@cat_id", this.category.ID);
                    myCommand.Parameters.AddWithValue("@userID", this.ID);

                    return myCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        private string EncryptPassword()
        {
            return new CrysptingService().Encrypt(this.Password, Program._KEY);
        }

        private string DeCryptPassword(string encryptedPwd)
        {
            return new CrysptingService().Decrypt(encryptedPwd, Program._KEY);
        }

        /// <summary>
        /// This gets a user based on a given ID
        /// </summary>
        /// <param name="userID">ID of the user</param>
        /// <returns></returns>
        public User GetUser(int userID)
        {
            try
            {
                string query = "SELECT * FROM users WHERE id = @user_id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@user_id", userID);

                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                this.ID = Convert.ToInt32(myReader[0]);
                                this.Name = myReader[1].ToString();
                                this.Password = this.DeCryptPassword(myReader[2].ToString());
                                this.role = this.GetUserRole(Convert.ToInt32(myReader[3]));
                                this.date = Convert.ToDateTime(myReader[4]);
                                this.category.getCategory(Convert.ToInt32(myReader[5]));
                                //this.Permissions.GetUserPermissions();
                                this.Permissions.GetUserPermissions(this);
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
