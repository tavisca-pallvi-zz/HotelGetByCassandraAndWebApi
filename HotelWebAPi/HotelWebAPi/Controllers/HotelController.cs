using HotelWebAPi.DataBase;
using HotelWebAPi.Models;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script;
using System.Web.Script.Serialization;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
namespace HotelWebAPi.Controllers
{
    //[Route("api/[controller]")]

    public class HotelController : ApiController
    {
        HotelJson hotelobj = new HotelJson();
        HotelThirdPartyApi hotelsData = new HotelThirdPartyApi();

        // [HttpGet]
       [Logger]
        public async Task<List<Hotel>> GetHotels()
         {
             // LogManager.WriteLog("GetAllHotels");
                JavaScriptSerializer jss = new JavaScriptSerializer();
            List<HotelContent> staticHotels = new List<HotelContent>();
            List<HotelModel> hotels = new List<HotelModel>(); ;
            List<Hotel> hotelList = new List<Hotel>();
            Task<List<HotelModel>> t1 =  hotelsData.GetHotelsFromApi();
            Task<List<HotelContent>> t2 = hotelobj.GetStaticHotels();
            staticHotels = await t2;
            hotels = await t1;

            //Task t1 = new Task(async () =>
            //{
            //    hotels = await hotelsData.GetHotelsFromApi();
            //});
            //Task t2 = new Task(async () =>
            //  {
            //      staticHotels = hotelobj.GetStaticHotels();
            //  });
            // t1.Start();
            // t2.Start();
            //List<Task> tasks = new List<Task> { t1, t2 };
            //Task result = Task.WhenAll(tasks);



            foreach (var hotel in hotels)
            {
                Hotel h = new Hotel();

                h.Id = hotel.Id;
                h.Name = hotel.Name;
                h.Location = hotel.Location;
                h.HotelRating = hotel.HotelRating;
                hotelList.Add(h);
            }

            var i = 0;
            foreach (var hotel in staticHotels)
            {
                hotelList[i].HotelImages = hotel.HotelImages;

                hotelList[i].Amenities = hotel.Amenities;
                i++;
            }
            return hotelList;
        }

        [HttpGet]
        [Logger]
        public async Task<HotelModel> GetHotelsById(int id)
        {
          
            List<HotelModel> hotels = new List<HotelModel>();
            HotelModel hotelSearch=new HotelModel();
         
                hotels = await hotelsData.GetHotelsFromApi();
           
            foreach (var hotel in hotels)
            {
                if (hotel.Id == id)
                {
                    hotelSearch = hotel;
                    break;
                }
            }
            LogManager.WriteLog("GetHotelsById called with the help of ID","Success");

            return hotelSearch;

        }
        [HttpPut]
        [Route("hotels/{hotelId}/rooms/{roomType}/{numberOfRoomsToBeBooked}")]
        public async void BookingHotel([FromUri]int hotelId, [FromUri] string roomType, [FromUri] int numberOfRoomsToBeBooked)
        {
            HotelModel hotel = await GetHotelsById(hotelId);
            SqlParameters obj = new SqlParameters();


            obj.HotelId = hotelId;
            obj.RoomType = roomType;
            obj.NoOfRooms = numberOfRoomsToBeBooked;
            obj.HotelName = hotel.Name;
            obj.Location = hotel.Location;

             HttpResponseMessage response = null;
            List<HotelContent> hotels;

            using (var client = new HttpClient())
            {
                string url = "http://localhost:63470/hotelservice.svc/hotel";
                response = await client.PutAsync(string.Format("http://localhost:63470/HotelService.svc/Hotel/{0}/rooms/{1}/{2}", hotelId, roomType, numberOfRoomsToBeBooked), null);

            }
            LogManager.WriteLog("decremented no of avilaible rooms from hotels", "succes");
            AddBookedHotels(obj);
        }

        [HttpPost] 

        public void AddBookedHotels(SqlParameters obj)
        {

            SqlRepo sqlRepo = new SqlRepo();
            sqlRepo.Add(obj);

            LogManager.WriteLog("AddBookedHotels called Add the booked hotels", "Success");
     
            
        }
        //
        //public async Task<string> book([FromUri]int hotelId, [FromUri] string roomType, [FromUri] int numberOfRoomsToBeBooked)
        //{
        //    string response = null;
        //    try
        //    {
        //        response = await HotelWCFService.Book(hotelId, roomType, numberOfRoomsToBeBooked);
        //        if (response.Equals("Success"))
        //        {
        //            Booking booking = new Booking()
        //            {
        //                HotelId = hotelId,
        //                RoomType = roomType,
        //                NumberOfRoomsBooked = numberOfRoomsToBeBooked
        //            };
        //            BookingSQLRepository repository = new BookingSQLRepository();
        //            repository.AddBooking(booking);
        //            LogService.GetLogger().LogAction("Put: Book", "Success", "Room Booked");
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        LogService.GetLogger().LogAction("Put: Book", "Failure", exception.Message);
        //    }
        //    return response;
        //}
        



    }
}
