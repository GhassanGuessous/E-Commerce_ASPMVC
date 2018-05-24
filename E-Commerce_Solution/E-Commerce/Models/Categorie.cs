using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefCat { get; set; }

        public string NomCat { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}