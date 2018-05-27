using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class MonPanier
    {
        public int NumArticle { get; set; }
        public string Designation { get; set; }
        public Double  PrixU { get; set; }
        public string photo { get; set; }
        public Nullable<int> QteArticle { get; set; }
        public String DateCmd { get; set; }
    }
}