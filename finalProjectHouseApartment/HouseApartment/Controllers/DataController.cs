using HouseApartments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace HouseApartment.Controllers
{
    public class DataController : ApiController
    {
        private IRoleServices _roleservices;
        public DataController(IRoleServices roleservices)
        {
            _roleservices = roleservices;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = prinicpal.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            var result = "Hello " + identity.Name + " Email: " + email + " Role: " + string.Join(",", roles.ToList());
            var data = new { name = identity.Name, details = result };
            return Ok(data);
        }

    }
}
