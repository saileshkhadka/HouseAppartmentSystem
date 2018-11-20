using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseApartment.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public object Name { get; internal set; }

        public int? EmployeeNumber { get; set; }
    }
}