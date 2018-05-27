using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class CommandesController : Controller
    {
        private E_CommerceContext db = new E_CommerceContext();

        // GET: Commandes
        public ActionResult Index()
        {
            var commandes = db.Commandes.Include(c => c.Article).Include(c => c.Client);
            return View(commandes.ToList());
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            List<Commande> cmds = db.Commandes.Where(c => c.NumClient == 1).ToList();
            ViewBag.ArticlesPanier = GetArticlesByCmds(cmds);
            ViewBag.c = new SelectList(db.Categories, "RefCat", "NomCat");
            return View();
        }

        public List<Article> GetArticlesByCmds(List<Commande> cmds)
        {
            List<Article> arts = new List<Article>();
            foreach (Commande cmd in cmds)
            {
                Article art = db.Articles.Where(a => a.NumArticle == cmd.NumArticle).First();
                arts.Add(art);
            }
            return arts;
        }

        public JsonResult GetArticlesByCategorie(int ID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Articles.Where(c => c.RefCat == ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStockByArticle(int ID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Articles.Where(a => a.NumArticle == ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Commandes.ToList(), JsonRequestBehavior.AllowGet);
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumCmd,DateCmd,NumClient,NumArticle,QteArticle")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                // Numero du client est recuperré a partir de la session 
                commande.NumClient = 1;
                commande.DateCmd = DateTime.Now.ToString();
                db.Commandes.Add(commande);

                // Mettre a jour le stock
                Article article = db.Articles.Where(a => a.NumArticle == commande.NumArticle).SingleOrDefault();

                if (article.Stock >= commande.QteArticle)
                {
                    article.Stock -= commande.QteArticle;
                    db.SaveChanges();
                }
                return RedirectToAction("Create");

            }
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumArticle = new SelectList(db.Articles, "NumArticle", "Designation", commande.NumArticle);
            ViewBag.NumClient = new SelectList(db.Clients, "NumClient", "Login", commande.NumClient);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumCmd,DateCmd,NumClient,NumArticle,QteArticle")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumArticle = new SelectList(db.Articles, "NumArticle", "Designation", commande.NumArticle);
            ViewBag.NumClient = new SelectList(db.Clients, "NumClient", "Login", commande.NumClient);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commande commande = db.Commandes.Find(id);
            db.Commandes.Remove(commande);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
