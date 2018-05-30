using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    public class CategorieImpl : ICategorie
    {


        EcommerceEntities1 db = new EcommerceEntities1();
       
        public List<Category> AllCategorie()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Article> AllArticle(int id)
        {
            IEnumerable<Article> articles = new List<Article>();
            articles = db.Articles.Where(p => p.RefCat == id);
            return articles;
        }

        public void AjouterCategorie(Category categorie)
        {
            db.Categories.Add(categorie);
            db.SaveChanges();
        }

        public void ModifierCategorie(Category categorie)
        {
            db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public Category GetCategorie(int id)
        {
            return db.Categories.Find(id);
          
        }

        public void SupprimerCategorie(int id)
        {
            Category categorie = GetCategorie(id);
            db.Categories.Remove(categorie);
            db.SaveChanges();

        }
    }
}