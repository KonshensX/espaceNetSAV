using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class UserPermission
    {
        private Database databaseObject;

        public User User { get; set; }
        public Permission Permission { get; set; }

        public bool Allowed { get; set; }

        public UserPermission()
        {
            this.databaseObject = new Database();
            this.User = new Admin.User();
            this.Permission = new Admin.Permission();
            Allowed = false;
        }

        public UserPermission (User user, Permission permission, bool allowed)
        {
            this.databaseObject = new Database();
            this.User = user;
            this.Permission = permission;
            this.Allowed = allowed;
        }

        //Fetch rows from the users_permissions table for the user
        //When creating a new user each user should have all permissions without any single permission
        //Check if the user is allowed to perform certain action


        /// <summary>
        /// This will fetch the users permission from the users_permissions table
        /// </summary>
        public List<UserPermission> FetchUserPermission(int userID)
        {
            try
            {
                string query = "SELECT * FROM users_permissions WHERE user_id = @user_id";
                List<UserPermission> list = new List<UserPermission>();
                using (MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@user_id", userID);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                UserPermission userPermission = new UserPermission();

                                userPermission.User.GetUser(Convert.ToInt32(myReader[0]));
                                userPermission.Permission.GetPermission(Convert.ToInt32(myReader[1]));
                                userPermission.Allowed = this.CheckIfAllowed(Convert.ToInt32(myReader[2]));

                                list.Add(userPermission);
                            }
                        }
                    }
                }
                return list;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }


        private bool CheckIfAllowed(int value)
        {
            switch (value)
            {
                case 1   :   return true;
                case 0   :   return false;
                default  :   return false;
            }
        }


        

    }
}
