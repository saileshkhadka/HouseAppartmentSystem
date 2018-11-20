using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Services
{
    public interface IDepartmentServices
    {
        List<DepartmentViewModel> ListDepartment();  
        bool AddDepartment(DepartmentViewModel model);
        bool UpdateDepartment(DepartmentViewModel model);
        DepartmentViewModel GetDepartmentByID(int id);
        bool DeleteDepartment(int id);
    }
}
