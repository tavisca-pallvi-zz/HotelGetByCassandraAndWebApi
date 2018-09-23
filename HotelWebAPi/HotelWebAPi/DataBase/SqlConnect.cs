using HotelWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelWebAPi.DataBase
{
    public class SqlConnect
    {
        

        SqlConnection connectionobject = new SqlConnection();
        public SqlConnection Connect()
        {
            LogManager.WriteLog("In SqlConnect Connect is called","success");
            connectionobject.ConnectionString = "Data Source=TAVDESK004;Initial Catalog=BookingDataBase;User ID=Sa;Password=test123!@#";
            connectionobject.Open();
            return connectionobject;
        }
    }
}