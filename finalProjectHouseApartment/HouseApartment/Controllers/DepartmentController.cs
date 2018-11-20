using HouseApartment.Services;
using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseApartment.Controllers
{
    public class DepartmentController : ApiController
    {
            private IDepartmentServices _departmentservices;
            public DepartmentController(IDepartmentServices departmentservices)
            {
                _departmentservices = departmentservices;
            }
            [HttpGet]
            [Route("api/department/getdepartmentdetails")]
            public IHttpActionResult GetUserList()
            {
                var data = _departmentservices.ListDepartment();//listDepartment which comes from interfaces.
                return Ok(data);
            }
            [HttpPost]
            [Route("api/department/adddepartments")]
            public IHttpActionResult AddDepartment([FromBody]DepartmentViewModel model)
            {
                var result = _departmentservices.AddDepartment(model);  //AddDepartments which comes from idepartmentcontroller
                return Ok(result);
            }
            [HttpPost]
            [Route("api/department/deletedepartments")]
            public IHttpActionResult DeleteDepartment([FromBody]int? id)
            {
                var data = _departmentservices.DeleteDepartment(id ?? 0);
                return Ok(data);
            }
            [HttpGet]
            [Route("api/department/getbyid")]
            public IHttpActionResult GetById(int id)
            {
                var data = _departmentservices.GetDepartmentByID(id);
                return Ok(data);
            }
            [HttpPost]
            [Route("api/department/updatedepartments")]
            public IHttpActionResult UpdateDepartment([FromBody]DepartmentViewModel model)  //for HttpPost we have to use FromBody 
            {
                var data = _departmentservices.UpdateDepartment(model);
                return Ok(data);
            }
        }
    
}