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

        public User()
        {
            this.databaseObject = new Database();
            this.date = DateTime.Now;
            this.role = Role.User;
        }

        public User(string username, string password)
        {
            this.databaseObject = new Database();
            this.ID = this.GetLastID();
            this.Name = username;
            this.Password = password;
            this.role = Role.User;
        }



        /// <summary>
        /// Gets the last user ID in the database
        /// </summary>
        /// <returns></returns>
        private int GetLastID()
        {
            string query = "SELECT MAX(id) FROM users";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
            return Convert.ToInt32(myCommand.ExecuteScalar());
            }

        }

        //Create user 

        public int createUser()
        {
            string query = "INSERT INTO `users`( `username`, `password`, `role`, `createdat`) VALUES (@username, @password, @role, @created)";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                myCommand.Parameters.AddWithValue("@username", this.Name);
                myCommand.Parameters.AddWithValue("@password", this.Password);
                myCommand.Parameters.AddWithValue("@role", this.GetUserRole(this.role)); //This needs more work 
                myCommand.Parameters.AddWithValue("@created", this.date);

                return Convert.ToInt32(myCommand.ExecuteNonQuery());
            }
        }

        //Get a user from the database
          
        //Update user

        //Fetch all users in the database

        public List<User> GetAllUsers()
        {
            List<User> myList = new List<User>();
            string query = "SELECT * FROM users";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while(myReader.Read())
                {
                    User user = new User();
                    user.ID = Convert.ToInt32(myReader[0]);
                    user.Name = myReader[1].ToString();
                    user.Password = myReader[2].ToString();

                    myList.Add(user);
                }
            }

            return myList;
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
        
    }
}
