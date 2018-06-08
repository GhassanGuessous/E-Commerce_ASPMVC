using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class PanierController : Controller
    {
        E_CommerceContext db = new E_CommerceContext();
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.e = new SelectList(db.Categories, "RefCat", "NomCat");
            return View();
        }

        public PartialViewResult AfficheDetails(int value)
        {

            ViewBag.e = value;

            List<Article> prod = new List<Article>();

            var x = from c in db.Articles where c.RefCat == value select new { c.Designation, c.PrixU, c.Photo, c.NumArticle };

            Article pro;
            foreach (var i in x)
            {
                pro = new Article();
                pro.Designation = i.Designation;
                pro.PrixU = i.PrixU;
                pro.Photo = i.Photo;
                pro.NumArticle = i.NumArticle;
                prod.Add(pro);
            }




            return PartialView("_AfficheDetails", prod);
        }

        public ActionResult Detail(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public ActionResult Get_panier()
        {

            List<MonPanier> prod = new List<MonPanier>();
            int numClient = Session["ConnecedClientId"] != null ? Int32.Parse(Session["ConnecedClientId"].ToString()) : 0;


            var x = (from c in db.Commandes
                     join d in db.Articles on c.NumArticle equals d.NumArticle
                     where c.NumClient == numClient
                     select new { c.QteArticle, c.DateCmd, d.Designation, d.PrixU, d.Photo, });
            MonPanier panier;
            foreach (var i in x)
            {
                panier = new MonPanier();
                panier.Designation = i.Designation;
                panier.PrixU = i.PrixU;
                panier.photo = i.Photo;
                panier.DateCmd = i.DateCmd;
                panier.QteArticle = i.QteArticle;
                prod.Add(panier);
            }


            return View(prod);
        }




    }
}