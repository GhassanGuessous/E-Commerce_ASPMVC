using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    public class ArticleImpl : IArticle
    {
        EcommerceEntities1 db = new EcommerceEntities1();
        List<MonPanier> prod = new List<MonPanier>();

        public void AjouterArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return db.Articles.Find(id);
        }

        public IEnumerable<MonPanier> Get_Panier(int id)
        {

            var x = (from c in db.Commandes
                     join d in db.Articles on c.NumArticle equals d.NumArticle
                     where c.NumClient == id
                     select new { c.QteArticle, c.DateCmd, d.Designation, d.PrixU, d.Photo, });

            MonPanier panier;
            foreach (var i in x)
            {
                panier = new MonPanier();
                panier.Designation= i.Designation;
                panier.PrixU = i.PrixU;
                panier.photo = i.Photo;
              
                panier.QteArticle = i.QteArticle;
                panier.DateCmd = i.DateCmd;
                prod.Add(panier);
            }


            return prod;
        }

        public void ModifierArticle(Article article)
        {
            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void SupprimerArticlee(int id)
        {
            Article article = GetArticle(id);
            db.Articles.Remove(article);
            db.SaveChanges();
        }
    }
    }