using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Article
    {
        //hada comment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumArticle { get; set; }

        public string Designation { get; set; }

        public double PrixU { get; set; }

        public int Stock { get; set; }

        public string Photo { get; set; }

        public int RefCat { get; set; }
        public Categorie Categorie { get; set; }
    }
}