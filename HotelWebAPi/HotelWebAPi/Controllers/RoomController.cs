using HotelWebAPi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HotelWebAPi.Controllers
{
    public class RoomController : ApiController
    {
        // GET: Room

        [System.Web.Http.HttpGet]
        [Logger]
        public async Task<List<RoomModel>> GetRoomsByHotelId(int id)
        {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<RoomModel> hotels = null;
            using (var client = new HttpClient())
            {

                var url = new Uri($"http://localhost:63470/HotelService.svc/Hotel/"+id+"");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                LogManager.WriteLog("async GetRoomsByHotelId called","success");

                return JsonConvert.DeserializeObject<List<RoomModel>>(json);
            }
        }
           
        

    }
}