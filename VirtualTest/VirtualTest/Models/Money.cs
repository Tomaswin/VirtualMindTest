using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace VirtualTest.Models
{
    [Serializable]
    [DataContract]
    public class Money
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string cotizacion { get; set; }
    }
}