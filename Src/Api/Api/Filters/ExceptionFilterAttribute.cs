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

            switch (exception)
            {
                case NotFoundException _:
                    // Add logging here
                    // In method {actionName} exception occurred: \n {exceptionMessage} \n {exceptionStack}

                    context.Result = new ContentResult
                    {
                        Content = $"Requested Id not found in database.",
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                    break;
                case DataBaseException _:
                    context.Result = new ContentResult
                    {
                        Content = $"Database error",
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;
                case InternalException _:
                    context.Result = new ContentResult
                    {
                        Content = $"Internal exception occured",
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;
                default:
                    context.Result = new ContentResult
                    {
                        Content = $"Unhandled exception occurred",
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
