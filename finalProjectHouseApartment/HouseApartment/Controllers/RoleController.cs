using HouseApartments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HouseApartment.Controllers
{
    public class RoleController : ApiController
    {
        private IRoleServices _roleservices;
        public RoleController(IRoleServices roleservices)
        {
            _roleservices = roleservices;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/role/getUserRoles")]
        public IHttpActionResult GetUserDetails()
        {
            var data = _roleservices.getAllDetails();
            return Ok(data);
        }
    }
}
