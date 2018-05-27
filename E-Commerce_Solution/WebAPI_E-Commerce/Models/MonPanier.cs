using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebAPI_E_Commerce.Models
{
    [DataContract]
    public class MonPanier
    {
        [DataMember]
        public int NumArticle { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public Nullable<Double> PrixU { get; set; }
        [DataMember]
        public string photo { get; set; }
        [DataMember]
        public Nullable<int> QteArticle { get; set; }
        [DataMember]
        public String DateCmd { get; set; }
    }
}