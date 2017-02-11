using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class Permissions
    {
        private Database databaseObject;
        public bool CanSeeHistory;
        public bool CanSeeBonList;

        public Permissions() { this.databaseObject = new Database(); }

        private Permission GetPermission(string permission)
        {
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
        }

        private void UpdateUserPermisisons()
        {
            //var result = this.GetPermission("")
        }

    }
}
