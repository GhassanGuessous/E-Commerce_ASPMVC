using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace E_Commerce.Models
{
    public class ClientUpdate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumClient { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Remote("isLoginExists", "Home", ErrorMessage = "Login déjà utilisé !")]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string MotDePasse { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("MotDePasse")]
        public string RetapezMotDePasse { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Nom { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Ville { get; set; }

        [Required]
        [Range(0600000001, 0799999999)]
        public string Tel { get; set; }
    }
}