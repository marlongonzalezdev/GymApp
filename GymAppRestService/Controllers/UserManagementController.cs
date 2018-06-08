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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [HttpGet]
        [Route("GetUser")]
        public void GetUser(string user, string password)
        {

            GymAppDBEntities context = new GymAppDBEntities();
            IGenericRepository repo = new EntityFrameworkRepository<DbContext>(context);
            IEnumerable<User> result = repo.GetAll<User>();
            Console.WriteLine(result);
        }
    }
}
