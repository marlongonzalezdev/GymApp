using Common;
using Persistence;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GymAppRestService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManagementController : ApiController
    {
        private readonly IGenericRepository _repo;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="repo"></param>
        public UserManagementController(IGenericRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Get user if exist
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [HttpGet]
        [Route("GetUser")]
        public async Task<HttpResponseMessage> GetUser(string user, string password)
        {
            string hashedPassword = Encryptor.Md5Hash(password);
            User result =  await _repo.GetFirstAsync<User>(s => s.Name == user && s.Password == hashedPassword);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        [HttpPost]
        [Route("CreateUser")]
        public async Task<HttpResponseMessage> PostUser(User user)
        {
            user.Password = Encryptor.Md5Hash(user.Password);
            _repo.Create<User>(user);
            await _repo.SaveAsync();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }
    }
}
