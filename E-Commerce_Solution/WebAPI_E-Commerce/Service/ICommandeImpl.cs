using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    public class ICommandeImpl : ICommande
    {
        EcommerceEntities1 db = new EcommerceEntities1();
        List<NumberCommandePerArticle> prod = new List<NumberCommandePerArticle>();
        public IEnumerable<NumberCommandePerArticle> GetNumberCommandePerArticle()
        {
            var query = from c in db.Articles
                        join p in db.Commandes
                        on c.NumArticle equals p.NumArticle
                        group new { c, p } by new { c.NumArticle } into g
                        select new
                        {
                          NumberCommande = g.Count(),
                            NumArticle = g.Key.NumArticle
                           
                        };

            IArticle articles = new ArticleImpl();
            foreach (var i in query)
            {
                NumberCommandePerArticle articlecommande = new NumberCommandePerArticle();
               
                articlecommande.NumberCommande= i.NumberCommande;
                articlecommande.ArticleName = articles.GetArticle(i.NumArticle).Designation;
                prod.Add(articlecommande);
            }


            return prod;
        }
    }
}