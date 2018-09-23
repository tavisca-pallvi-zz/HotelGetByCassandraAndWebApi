using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelsBook
{
    [DataContract]

    public class HotelModel
    {

        [DataMember]
        public string Name;

        [DataMember]
        public int Id;

        [DataMember]
        public string Location;

        [DataMember]
        public int HotelRating;
    }
}