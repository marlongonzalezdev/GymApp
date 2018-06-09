using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Persistence;

namespace GymAppRestService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManagementController : ApiController
    {
        private readonly IGenericRepository _repo;
        public UserManagementController(IGenericRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [HttpGet]
        [Route("GetUser")]
        public HttpResponseMessage GetUser(string user, string password)
        {
            var result = _repo.GetFirst<User>(s => s.Name == "Nestor");
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
