using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_E_Commerce.Models
{
  
        [MetadataType(typeof(CategorieMetaData))]
        public partial class Category
        {

        }

        public class CategorieMetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un nouveau catégorie")]
            public string Nomcatg { get; set; }
        }
    }
