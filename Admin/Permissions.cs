using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace espaceNetSAV.Admin
{
    class Permissions
    {
        private Database databaseObject;
        public bool CanSeeHistory { get; set; }
        public bool CanValideDossier { get; set; }

        List<UserPermission> UserPermissions;

        //public Permissions()
        //{
            
        //}

        public Permissions() { this.databaseObject = new Database(); UserPermissions = new List<UserPermission>(); }

        //private Permission GetPermission(string permission)
        //{
            /*
            try
            {
                //TODO: Fix the query 
                string query = "SELECT * FROM permissions WHERE name like @permission";
                Permission permissionObject = new Permission();
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@permission", permission);

                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                permissionObject.ID = Convert.ToInt32(myReader[0]);
                                permissionObject.Name = myReader[1].ToString();
                                permissionObject.permission = permissionObject.GetPermissionStatus(Convert.ToInt32(myReader[2]));
                            }
                        }
                    }
                }

                return permissionObject;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
             * */
        //}
        private void UpdateUserPermisisons()
        {
            //var result = this.GetPermission("")
        }


        /// <summary>
        /// Update the permissions according to result in the list.
        /// </summary>
        /// <returns></returns>
        public Permissions GetUserPermissions()
        {
            //Will get the user permission data 

            List<UserPermission> myPermissionsList = new List<UserPermission>();

            myPermissionsList = new UserPermission().FetchUserPermissions(Program._USER.ID);

            foreach (UserPermission permission in myPermissionsList)
            {
                this.UpdatePermissions(permission);
            }
            
            //this.UpdatePermissions();
            return this;

            //Update the above values (the permissions)
        }


        /// <summary>
        /// Get user permissions based on given user object
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns></returns>
        public Permissions GetUserPermissions(User user)
        {
            //Will get the user permission data 

            List<UserPermission> myPermissionsList = new List<UserPermission>();

            myPermissionsList = new UserPermission().FetchUserPermissions(user.ID);

            foreach (UserPermission permission in myPermissionsList)
            {
                this.UpdatePermissions(permission);
            }

            //this.UpdatePermissions();
            return this;

            //Update the above values (the permissions)
        }

        /// <summary>
        /// Get user permissions based on given user ID
        /// </summary>
        /// <param name="user">User ID</param>
        /// <returns></returns>
        public Permissions GetUserPermissions(int user)
        {
            //Will get the user permission data 

            List<UserPermission> myPermissionsList = new List<UserPermission>();

            myPermissionsList = new UserPermission().FetchUserPermissions(user);

            foreach (UserPermission permission in myPermissionsList)
            {
                this.UpdatePermissions(permission);
            }

            //this.UpdatePermissions();
            return this;

            //Update the above values (the permissions)
        }

        private void UpdatePermissions(UserPermission permission)
        {
            if (permission.Permission.Name.Contains("history"))
            {
                if (permission.Allowed)
                    this.CanSeeHistory = true;
            }
            if (permission.Permission.Name.Contains("valide"))
            {
                if (permission.Allowed)
                this.CanValideDossier = true;
            }
        }
        
        int permissionsCount = 2;

        /// <summary>
        /// This will insert user permissions in the pivot table
        /// </summary>
        public void NewUserPermissions()
        {
            

        }


        internal void CreateEmptyUserPermissions(User user)
        {
            try
            {
                //First Permission 
                Permission historyPermisison = new Permission().GetPermission(1);

                //Second Permission
                Permission validePermission = new Permission().GetPermission(2);

                //Persiting the objects to the pivot table
                string query = "INSERT INTO users_permissions (`user_id`, `permission_id`, `allowed`) VALUES (@user_id, @permission_id, @allowed)";
                for (int i = 0; i < permissionsCount; i++)
                {
                    this.databaseObject.openConnection();
                    using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                    {
                        myCommand.Parameters.AddWithValue("@user_id", user.ID);
                        myCommand.Parameters.AddWithValue("@permission_id", i + 1);
                        myCommand.Parameters.AddWithValue("@allowed", 0);
                        myCommand.ExecuteNonQuery();
                    }
                    this.databaseObject.closeConnection();
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }
    }
}
