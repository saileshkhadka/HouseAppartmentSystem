using HouseApartment.Crypto;
using HouseApartment.Tables;
using HouseApartment.ViewModel;
using HouseApartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseApartment.Authorization
{
    public static class CheckUser
    {
       
        //check if user exist
        public static UserViewModel IsUserExist(string username)
        {
            
            using (DataContext db=new DataContext())
            {
                
                var IsExistUser = db.Users.Where(x => x.Username == username).FirstOrDefault();
                if (IsExistUser != null)
                {
                    var data = new UserViewModel()
                    {
                        UserID=IsExistUser.UserID,
                        Username = IsExistUser.Username,
                        Password=IsExistUser.Password,
                        FirstName = IsExistUser.FirstName,
                        LastName = IsExistUser.LastName,
                        DateOfBirth = IsExistUser.DateOfBirth,
                        EmailID = IsExistUser.EmailID,
                    };
                    var roleDetails = GetRoleDetails(data.UserID);
                    data.RoleName = roleDetails.RoleName;
                    return data;
                }
                else
                {
                    return null;
                }

            }
          
        }

        //check if role exist
        public static RoleNamesViewModel GetRoleDetails(int UserID)
        {
            using (DataContext db = new DataContext())
            {
                var getRoles = db.Roles.Join(db.UserRoles,
                r => r.RoleID,
                ur => ur.RoleID,
                (r, ur) => new { roles = r, userroles = ur }).Where(x => x.userroles.UserID == UserID)
                .Select(x => new RoleNamesViewModel()
                {
                    RoleID = x.userroles.RoleID,
                    RoleName = x.roles.RoleName
                }).SingleOrDefault();
                return getRoles;
            }
        }
    }
}