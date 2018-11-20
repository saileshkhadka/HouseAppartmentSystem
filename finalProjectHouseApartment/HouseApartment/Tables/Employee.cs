using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HouseApartment.Tables
{
    public class Employee
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        

    }
}