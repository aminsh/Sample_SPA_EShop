using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.OData.Extensions;
using Core;

namespace App.Utility
{
    public static class RequestExtension
    {
        public static HttpResponseMessage ToExceptionResponse(this HttpRequestMessage request ,IResult result)
        {
            var validationException = new ValidationException {Errors = result.Errors};
            return request.CreateErrorResponse(HttpStatusCode.NotAcceptable, validationException);
        }
    }
}