using HotelWebAPi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HotelWebAPi
{
    public class HotelJson
    {
        
        public  async Task<List<HotelContent>> GetStaticHotels()
        {
            var result = "";
            JObject json;
            string sJSONdata = "";
            List<HotelContent> hotels;
            var path = @"C:\Users\pgoel\Desktop\hotel.json";
            using (StreamReader reader = new StreamReader(path))
            {
                sJSONdata = reader.ReadToEnd();

                hotels = JsonConvert.DeserializeObject<List<HotelContent>>(sJSONdata);

            }
            LogManager.WriteLog("async getting Static Hotel called", "success");

            return hotels;

        }
    }
}