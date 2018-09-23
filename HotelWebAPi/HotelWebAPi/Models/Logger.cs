using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebAPi.Models
{



    public  class LogManager
    {
        public static LogManager _instance;

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogManager();

                return _instance;
            }
        }

       public static void WriteLog(string request, string response)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hoteldatabase");
            string query = "Insert into hoteldatabase.logger(loggerid,request,response,logdate) values(uuid(),'" + request + "','" + request + "',dateof(now()))";
            session.Execute(query);
        }


    }
}

