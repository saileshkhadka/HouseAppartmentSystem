using HouseApartment.Tables;
using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Services
{
  public  interface IUserServices
    {
      UserViewModel  Insert(UserViewModel model);
        bool IsExistEmail(string EmailID);
    }
}
