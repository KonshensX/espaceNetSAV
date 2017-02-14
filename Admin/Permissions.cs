using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace espaceNetSAV.Admin
{
    class Permissions
    {
        private Database databaseObject;
        public bool CanSeeHistory { get; set; }
        public bool CanSeeBonList { get; set; }

        List<UserPermission> UserPermissions;

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
                if (permission.Permission.Name.Contains("history"))
                {
                    this.CanSeeHistory = true;
                } 
                if (permission.Permission.Name.Contains("valdie"))
                {
                    this.CanSeeBonList = true;
                }
                
            }
            
            //this.UpdatePermissions();
            return this;

            //Update the above values (the permissions)
        }

        private void UpdatePermissions()
        {
            throw new NotImplementedException();
        }

        

    }
}
