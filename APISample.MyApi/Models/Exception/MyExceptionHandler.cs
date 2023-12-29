using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace APISample.MyApi.Models.Exception
{
    public class MyExceptionHandler : ExceptionHandler
    {

        public override void Handle(ExceptionHandlerContext context)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Access to the resource is unauthorized.";
                status = HttpStatusCode.Unauthorized;
            }
            else
            {
                message = "Internal Server Error.";
                status = HttpStatusCode.InternalServerError;
            }

            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = message

            };

            //context.Re = new HttpResponseMessage
            //{
            //    Content = new StringContent(message),
            //    StatusCode = status
            //};
        }


        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }

}
