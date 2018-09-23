using HotelsBook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebApi.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        HotelJson hotelobj = new HotelJson();
        [HttpGet]
        [Route("{id}")]
     public async List<HotelModel>GetHotels()
        {
            List<HotelModel> hotels=null;

            hotels= hotelobj.GetStaticHotels();
            hotels = Hotel();
           
    }
}