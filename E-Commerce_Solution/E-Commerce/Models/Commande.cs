using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumCmd { get; set; }

        public string DateCmd { get; set; }

        public int NumClient { get; set; }
        public Client Client { get; set; }

        public int NumArticle { get; set; }
        public Article Article { get; set; }

        public int QteArticle { get; set; }
        
    }
}