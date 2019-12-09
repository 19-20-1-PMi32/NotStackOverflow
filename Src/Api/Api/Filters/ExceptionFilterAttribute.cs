using BLL.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Filters
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;

            var exception = context.Exception;

            if (exception is NotFoundException)
            {
                // Add logging here
                // In method {actionName} exception occurred: \n {exceptionMessage} \n {exceptionStack}

                context.Result = new ContentResult
                {
                    Content = $"Requested Id not found in database.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else if (exception is DataBaseException)
            {
                context.Result = new ContentResult
                {
                    Content = $"Database error",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else if (exception is InternalException)
            {
                context.Result = new ContentResult
                {
                    Content = $"Internal exception occured",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = $"Unhandled exception occurred",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
