using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebAPi.DataBase
{
    public class LoggerDatabase
    {
        public static void Add()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hoteldatabase");
            string query = "Insert into hoteldatabase.logger(loggerid,response,request,logdate) values(uuid(),Loggers.Response, Loggers.Request,dateof(now()))";
            session.Execute(query);
            

       
        }
    }
}