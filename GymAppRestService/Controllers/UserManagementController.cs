using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymAppRestService.Controllers
{
    public class UserManagementController : ApiController
    {
        [HttpGet]
        [Route("GetUser")]
        public void GetUser(string user, string password)
        {

        }
    }
}
