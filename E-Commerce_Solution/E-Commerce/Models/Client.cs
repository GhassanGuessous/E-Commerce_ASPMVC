using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumClient { get; set; }

        public string Login { get; set; }

        public string MotDePasse { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string Ville { get; set; }

        public string Tel { get; set; }
    }
}