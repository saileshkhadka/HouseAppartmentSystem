using HouseApartment.Services;
using HouseApartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HouseApartment.Controllers
{
    public class UserController : ApiController
    {
        private IUserServices _userservices;
        public UserController(IUserServices userservices)
        {
            _userservices = userservices;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult Post([FromBody] UserViewModel model)
        {
           var data=  _userservices.Insert(model);
            return Ok("Now Server Time is:" + DateTime.Now.ToString());
        }

    }
}
