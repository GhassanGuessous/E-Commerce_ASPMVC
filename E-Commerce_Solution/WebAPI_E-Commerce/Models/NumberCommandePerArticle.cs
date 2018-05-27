using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebAPI_E_Commerce.Models
{[DataContract]
    public class NumberCommandePerArticle
    {
        [DataMember]
        public int NumberCommande { get; set; }
        [DataMember]
        public String ArticleName { get; set; }
    }
}