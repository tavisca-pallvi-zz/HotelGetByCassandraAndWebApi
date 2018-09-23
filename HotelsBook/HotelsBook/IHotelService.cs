using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelsBook
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelService" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {
       
        [OperationContract]
        [WebGet(UriTemplate = "/Hotel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<HotelModel> Hotel();

        [OperationContract]
        [WebGet(UriTemplate = "/Hotel/{Id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

       List<RoomModel> RoomsByHotel(string Id);
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/Hotel/{hotelId}/rooms/{roomType}/{numberOfRoomsToBeBooked}",Method ="PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        void BookRoom(string hotelId, string roomType, string numberOfRoomsToBeBooked);


    }
}
