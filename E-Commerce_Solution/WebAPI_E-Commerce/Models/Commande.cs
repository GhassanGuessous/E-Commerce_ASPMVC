//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_E_Commerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commande
    {
        public int NumCmd { get; set; }
        public string DateCmd { get; set; }
        public int NumClient { get; set; }
        public int NumArticle { get; set; }
        public int QteArticle { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Client Client { get; set; }
    }
}