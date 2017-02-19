using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    public enum EnumUserPermission {
        //1
        Allowed,
        //0
        NotAllowed
    }
    class Permission
    {
        private Database databaseObject;
        public int ID { get; set; }
        public string Name { get; set; }

        public Permission()
        {
            this.databaseObject = new Database();
        }

        public Permission (int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Permission GetPermission(int permissionID)
        {
            try
            {
                string query = "SELECT * FROM permissions WHERE id = @permission_id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@permission_id", permissionID);
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
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Get the user permission based on the ID
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public EnumUserPermission GetPermissionStatus(int permission)
        {
            switch (permission)
            {
                case 1:
                    return EnumUserPermission.Allowed;
                case 2 :
                    return EnumUserPermission.NotAllowed;
                default:
                    return EnumUserPermission.NotAllowed;
            }
        }

        //Gets the user permissions based on the UserPermission Enum 
        public int GetPermissionStatus(EnumUserPermission permission)
        {
            switch (permission)
            {
                case EnumUserPermission.Allowed:
                    return 1;
                case EnumUserPermission.NotAllowed:
                    return 0;
                default: 
                    return 0;
            }
        }

       
    }
}
