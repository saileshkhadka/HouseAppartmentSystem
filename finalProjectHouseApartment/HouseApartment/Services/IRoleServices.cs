
using HouseApartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseApartment.Tables;

namespace HouseApartments.Services
{
  public  interface IRoleServices
  {
       UserRole CreateOrUpdate(UserRole model);

       List<RolesViewModel> getAllDetails();
       List<RoleNamesViewModel> getAllRoleList();
    }
}
