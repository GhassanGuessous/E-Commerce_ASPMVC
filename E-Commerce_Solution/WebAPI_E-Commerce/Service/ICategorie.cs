﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    interface ICategorie
    {
        List<Category> AllCategorie();
        IEnumerable<Article> AllArticle(int id);
      void AjouterCategorie(Category categorie);
     void ModifierCategorie(Category categorie);
      Category GetCategorie(int id);
      void  SupprimerCategorie(int id);
    }
}
