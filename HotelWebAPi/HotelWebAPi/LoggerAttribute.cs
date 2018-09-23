using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using HotelWebAPi.Models;
using HotelWebAPi.DataBase;

namespace HotelWebAPi
{
    public class LoggerAttribute : ResultFilterAttribute,IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                Loggers.Response = "Success";
            }
            else
            {
                Loggers.Response = "Failure";
           
            }
            Loggers.LogId = Guid.NewGuid();
            // CassendraLogger.Add();
            LoggerDatabase.Add();
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string req = "";
            req = context.RouteData.Values["action"].ToString() + context.RouteData.Values["controller"].ToString();
            Loggers.Request = req;
            Loggers.Response = "NULL";
   
        }
    }
}