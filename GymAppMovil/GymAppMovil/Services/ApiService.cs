using GymAppMovil.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymAppMovil.Services
{
    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifica tu configuración a internet.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifica tu conexión a internet.",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

        GenericApiService genericApiService;
        public ApiService()
        {
            genericApiService = new GenericApiService();
        }

        public async Task<User> GetUser(string User, string Password)
        {
            string urlPrefix = ServiceConfig.getUser+"?user=" + User + "&password=" + Password; 
            var response =  await genericApiService.Get<User>(ServiceConfig.baseUrl, urlPrefix);
            return (User)response.Result;          
        }
    }
}
