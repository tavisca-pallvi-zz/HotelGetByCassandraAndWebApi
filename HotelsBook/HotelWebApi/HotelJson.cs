using HotelsBook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HotelWebApi
{
    public class HotelJson
    {

        [HttpGet]
        [Route("{id}")]


        public List<HotelModel> GetStaticHotels()
        {
            var result = "";
            JObject json;
            string sJSONdata = "";
            List<HotelModel> hotels;
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/" + "hotel.json";
            using (StreamReader reader = new StreamReader(path))
            {
                sJSONdata = reader.ReadToEnd();

                hotels = JsonConvert.DeserializeObject<List<HotelModel>>(sJSONdata);

            }

            return hotels;

        }
    }
}