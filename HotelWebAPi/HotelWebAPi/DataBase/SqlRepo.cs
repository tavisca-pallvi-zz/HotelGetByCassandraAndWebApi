using HotelWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelWebAPi.DataBase
{
    public class SqlRepo
    {
        public void Add(SqlParameters bookingModel)
        {
            SqlConnect connect = new SqlConnect();
            SqlConnection connectionobject = connect.Connect();

            string query = "insert into Booking values(@HotelId,@RoomType,@NoOfRooms,@HotelName,@Location)";
            SqlCommand cmd = new SqlCommand(query, connectionobject);

            cmd.Parameters.Add(new SqlParameter("@HotelId", bookingModel.HotelId));
            cmd.Parameters.Add(new SqlParameter("@RoomType", bookingModel.RoomType));
            cmd.Parameters.Add(new SqlParameter("@NoOfRooms", bookingModel.NoOfRooms));
            cmd.Parameters.Add(new SqlParameter("@HotelName", bookingModel.HotelName));
            cmd.Parameters.Add(new SqlParameter("@Location", bookingModel.Location));
            cmd.ExecuteNonQuery();
            connectionobject.Close();
            LogManager.WriteLog("async ADD called","sUCCESS");

        }
    }
}
