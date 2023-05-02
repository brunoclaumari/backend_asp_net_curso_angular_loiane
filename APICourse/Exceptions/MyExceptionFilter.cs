using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APICourse.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace APICourse.Exceptions
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = new CustomResponse { IsSucessfull = false};
            if (context.Exception is MyEntityNotFoundException)
            {
                response.Message = context.Exception.Message;
                response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status404NotFound};
            }
            else if(context.Exception is CreateFailException)
            {
                response.Message = context.Exception.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status400BadRequest };
            }
            else
            {                
                context.Exception = new Exception("Ocorreu um erro ao tentar processar a requisição");
                response.Message = context.Exception.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
