using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseApartment.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
       
    }
}