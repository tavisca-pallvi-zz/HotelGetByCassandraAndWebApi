using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelsBook
{
    [DataContract]

    public class RoomModel
    {
        [DataMember]
        public string RoomType;
        [DataMember]
        public int NoOfRooms;
        [DataMember]
        public int HotelId;
    }
}