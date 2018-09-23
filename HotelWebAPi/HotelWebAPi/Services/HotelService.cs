using HotelWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelWebAPi.Services
{
    public class HotelService
    {
        public async void book(int id, string type, int bookedRoom)
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:63470/hotelservice.svc/hotel";
                HttpResponse response= await client.PutAsync(string.Format("http://localhost:63470/HotelService.svc/Hotel/{0}/rooms/{1}/{2}", Id, Type, bookedRoom), null);

            }
           LogManager.WriteLog("decremented no of avilaible rooms from hotels", "succes");
          
        }
    }
}