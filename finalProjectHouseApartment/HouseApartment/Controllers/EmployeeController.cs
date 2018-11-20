using HouseApartment.Services;
using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseApartment.Controllers
{
    public class EmployeeController:ApiController
    {

        private IEmployeeServices _employeeservices;
        public EmployeeController(IEmployeeServices employeeservices)
        {
            _employeeservices = employeeservices;
        }
        [HttpGet]
        [Route("api/employee/getemployeedetails")]
        public IHttpActionResult GetUserList()
        {
            var data = _employeeservices.ListEmployee();//listEmployee which comes from interfaces.
            return Ok(data);
        }
        [HttpPost]
        [Route("api/employee/addemployees")]
        public IHttpActionResult AddEmployee([FromBody]EmployeeViewModel model)
        {
            var result = _employeeservices.AddEmployee(model);  //AddEmployees which comes from iemployeecontroller
            return Ok(result);
        }
        [HttpGet]
        [Route("api/employee/deleteemployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var data = _employeeservices.DeleteEmployee(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/employee/Update")]
        public IHttpActionResult UpdateEmployee([FromBody]EmployeeViewModel model)  //for HttpPost we have to use FromBody 
        {
            var data = _employeeservices.UpdateEmployee(model);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/employee/getById")]
        public IHttpActionResult GetById(int id)
        {
            var data = _employeeservices.GetEmployeeById(id);
            return Ok(data);
        }
    }
}

    
