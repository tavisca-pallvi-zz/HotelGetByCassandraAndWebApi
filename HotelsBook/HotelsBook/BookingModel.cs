using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelsBook
{
    [DataContract]
    public class BookingModel
    {
        [DataMember]
        public string Name;

        [DataMember]
        public int Id;

        [DataMember]
        public int NoOfRooms;

        [DataMember]
        public string RoomType;
    }
}