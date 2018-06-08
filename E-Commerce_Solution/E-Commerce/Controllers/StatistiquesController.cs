using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class StatistiquesController : Controller
    {
      
        private E_CommerceContext db = new E_CommerceContext();
        public ActionResult Index()
        {
            return View();
        }
    
        public JsonResult GetData()
            {
            List<NumberCommandePerArticle> prod = new List<NumberCommandePerArticle>();
            var query = from c in db.Articles
                        join p in db.Commandes
                        on c.NumArticle equals p.NumArticle
                        group new { c, p } by new { c.Designation} into g
                        select new
                        {
                            NumberCommande = g.Count(),
                            NumArticle = g.Key.Designation,

                        };


            foreach (var i in query)
            {
                NumberCommandePerArticle articlecommande = new NumberCommandePerArticle();

                articlecommande.NumberCommande = i.NumberCommande;
           
                articlecommande.ArticleName = i.NumArticle;
                prod.Add(articlecommande);
            }




            return Json(prod, JsonRequestBehavior.AllowGet);
            }
        Article GetArticle(int numero)
        {return db.Articles.Find(numero);

        }



        }
    }
