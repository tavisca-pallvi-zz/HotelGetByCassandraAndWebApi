using Cassandra;
using HotelsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Script.Serialization;

namespace HotelsBook
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        List<HotelModel> hotels = new List<HotelModel>();
        string name = "";
        int id;
        string address;
        int rating;
    
        public List<HotelModel> Hotel()
        {
            List<HotelModel> hotels = new List<HotelModel>();

            HotelModel hotel;
            CassandraConnect obj = new CassandraConnect();
            Cassandra.ISession session = obj.Connect();
            string query = "select * from  hotel";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var res = session.Execute(query);
            foreach (var row in res)
            {

                hotel = new HotelModel();
                hotel.Name = row.GetValue<string>("hotelname");
                hotel.Id = row.GetValue<int>("hotelid");
                hotel.Location = row.GetValue<string>("hoteladdress");
                hotel.HotelRating = row.GetValue<int>("hotelrating");
                hotels.Add(hotel);

            }
            return hotels;

            //  string output = jss.Serialize(hotels);
            //return output;


        }
        public List<RoomModel> RoomsByHotel(string Id)
        {
            int hotelid = Int32.Parse(Id);
            List<RoomModel> rooms = new List<RoomModel>();
            RoomModel room;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            CassandraConnect obj = new CassandraConnect();
            Cassandra.ISession session = obj.Connect();
            string query = "select * from  rooms where hotelid="+ hotelid +" ALLOW FILTERING";
            
            var res = session.Execute(query);
            foreach (var row in res)
            {
                room = new RoomModel();
                room.NoOfRooms = row.GetValue<int>("noofrooms");
                room.RoomType = row.GetValue<string>("roomtype");
                room.HotelId = row.GetValue<int>("hotelid");
                rooms.Add(room);

            }
            //string output = jss.Serialize(rooms);

            return rooms;

        }
        public HotelModel GetHotelById(string Id)
        {
            int hotelid = Int32.Parse(Id);
            JavaScriptSerializer jss = new JavaScriptSerializer();

            CassandraConnect obj = new CassandraConnect();
            Cassandra.ISession session = obj.Connect();
            string query = "select * from  hotel where hotelid=" + hotelid + " ALLOW FILTERING";
            HotelModel hotel=null;
            var res = session.Execute(query);
            foreach (var row in res)
            {
                hotel = new HotelModel();
                hotel.Name = row.GetValue<string>("hotelname");
                hotel.Id = row.GetValue<int>("hotelid");
                hotel.Location = row.GetValue<string>("hoteladdress");
                hotel.HotelRating = row.GetValue<int>("hotelrating");
                hotels.Add(hotel);

            }
          //  string output = jss.Serialize(hotel);

            return hotel;

        }
            public void BookRoom(string hotelId,string roomType,string numberOfRoomsToBeBooked)
        {
            int hotelid = Int32.Parse(hotelId);

            int RoomsToBeBooked = Int32.Parse(numberOfRoomsToBeBooked);

            RoomModel room;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            int val;
            CassandraConnect obj = new CassandraConnect();
            Cassandra.ISession session = obj.Connect();
            string query = "select noofrooms from  rooms where hotelid= "+ hotelid + "   AND roomType= '"+ roomType +"' ALLOW FILTERING";
            var row = session.Execute(query).First();
            int v = int.Parse(row["noofrooms"].ToString());
            val = v - RoomsToBeBooked;
            string updatequery = "Update hoteldatabase.rooms Set noofrooms = "+ val +" where hotelid = "+ hotelid + "   AND roomType = '"+ roomType + "'";
            session.Execute(updatequery);
         
        }
    }
}