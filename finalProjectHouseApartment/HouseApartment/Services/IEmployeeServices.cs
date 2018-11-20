using HouseApartment.Tables;
using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Services
{
    public interface IEmployeeServices
    {
        List<EmployeeViewModel> ListEmployee();
        bool AddEmployee(EmployeeViewModel model);
        bool UpdateEmployee(EmployeeViewModel model);
        EmployeeViewModel GetEmployeeById(int id);
        bool DeleteEmployee(int id);
    }
}
