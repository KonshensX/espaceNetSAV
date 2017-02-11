using System;

namespace espaceNetSAV.Admin
{
    public enum UserPermission {
        //1
        Allowed,
        //0
        NotAllowed
    }
    class Permission
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserPermission permission;

        public Permission()
        {
            permission = UserPermission.NotAllowed;
        }

        /// <summary>
        /// Get the user permission based on the ID
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public UserPermission GetPermissionStatus(int permission)
        {
            switch (permission)
            {
                case 1:
                    return UserPermission.Allowed;
                case 2 :
                    return UserPermission.NotAllowed;
                default:
                    return UserPermission.NotAllowed;
            }
        }

        //Gets the user permissions based on the UserPermission Enum 
        public int GetPermissionStatus(UserPermission permission)
        {
            switch (permission)
            {
                case UserPermission.Allowed:
                    return 1;
                case UserPermission.NotAllowed:
                    return 0;
                default: 
                    return 0;
            }
        }
    }
}
