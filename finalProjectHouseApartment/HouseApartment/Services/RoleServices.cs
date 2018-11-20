using HouseApartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseApartment.Tables;

namespace HouseApartments.Services
{
  public  class RoleServices:IRoleServices
    {
      protected DataContext db;
      public RoleServices()
      {
          db = new DataContext();
      }

        public List<RolesViewModel> getAllDetails()
        {
            var query = (from u in db.Users
                         join urs in db.UserRoles on u.UserID equals urs.UserID into r
                         from urs in r.DefaultIfEmpty()
                         join ro in db.Roles on urs.RoleID equals ro.RoleID into ur
                         from ro in ur.DefaultIfEmpty()
                         where u.UserID > 0
                         select new RolesViewModel()
                         {
                             UserRolesId = urs.UserRolesId,
                             UserID = u.UserID,
                             RoleID = ro.RoleID,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             EmailID = u.EmailID,
                             DateOfBirth = u.DateOfBirth,
                             IsEmailVerified = u.IsEmailVerified,
                             RoleName = ro.RoleName,
                             UserName = u.Username
                         }).ToList();
            return query;
        }


        public List<RoleNamesViewModel> getAllRoleList()
        {
            var query = db.Roles.Select(x => new RoleNamesViewModel()
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
            return query;
        }

        public UserRole CreateOrUpdate(UserRole model)
        {
            var isExist = db.UserRoles.Where(x => x.UserRolesId == model.UserRolesId).FirstOrDefault();
            if (isExist != null)
            {
                isExist.RoleID = model.RoleID;
                isExist.UserID = model.UserID;
                db.SaveChanges();
            }
            else
            {
                var data = new UserRole() { RoleID = model.RoleID, UserID = model.UserID };
                db.UserRoles.Add(model);
                db.SaveChanges();
            }
            return model;
        }
    }
}
