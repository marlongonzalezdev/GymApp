using System;
using System.Net;

namespace GymAppMovil.Models
{
    public class ResponseData
    {
        public string Version { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
        public DateTime Timestamp { get; set; }
        public long? Size { get; set; }

    }
}
