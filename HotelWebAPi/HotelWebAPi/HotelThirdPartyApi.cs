using HotelWebAPi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HotelWebAPi
{
    public class HotelThirdPartyApi
    {
        public async Task<List<HotelModel>> GetHotelsFromApi()
        { List<HotelModel> hotels = null;
            string json=null;

            try
            {
                using (var client = new HttpClient())
                {

                    var url = new Uri($"http://localhost:63470/HotelService.svc/Hotel");
                    var response = await client.GetAsync(url);
                  
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();
                    }
                    LogManager.WriteLog("async hotelthird PartyApi hotels get", "success");

                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("async hotelthird PartyApi hotels get", "failure");


            }
            return JsonConvert.DeserializeObject<List<HotelModel>>(json);


        }

    }
}