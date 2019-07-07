using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;

namespace EmployeeWebApi.Extension
{

    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public HttpActionResult Error { get; set; }
    }
}