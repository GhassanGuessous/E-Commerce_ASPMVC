using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace E_Commerce.Models
{
    public class ClientLogin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumClient { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string MotDePasse { get; set; }
        
        public string Nom { get; set; }

        public string Prenom { get; set; }
        
        public string Email { get; set; }

        public string Ville { get; set; }

        public string Tel { get; set; }
    }
}