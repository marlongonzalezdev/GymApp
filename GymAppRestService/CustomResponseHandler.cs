using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GymAppRestService
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            try
            {
                return GenerateResponse(request, response);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        private HttpResponseMessage GenerateResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            string errorMessage = null;
            HttpStatusCode statusCode = response.StatusCode;
            if (!IsResponseValid(response))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Invalid response..");
            }

            if (response.TryGetContentValue(out object responseContent))
            {
                if (responseContent is HttpError httpError)
                {
                    errorMessage = httpError.Message;
                    statusCode = HttpStatusCode.InternalServerError;
                    responseContent = null;
                }
            }
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            var responseMetadata = new ResponseMetadata
            {
                Version = "1.0",
                StatusCode = statusCode,
                Result = responseContent,
                Timestamp = dt,
                ErrorMessage = errorMessage,
                Size = responseContent.ToString().Length
            };
            var result = request.CreateResponse(response.StatusCode, responseMetadata);
            return result;
        }
        private static bool IsResponseValid(HttpResponseMessage response)
        {
            return (response != null) && (response.StatusCode == HttpStatusCode.OK);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ResponseMetadata
    {
        public string Version { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
        public DateTime Timestamp { get; set; }
        public long? Size { get; set; }
      
    }

}