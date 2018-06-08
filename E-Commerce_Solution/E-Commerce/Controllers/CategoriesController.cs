using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class CategoriesController : Controller
    {
    
        private E_CommerceContext context = new E_CommerceContext();
        private E_CommerceContext db = new E_CommerceContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());

        }

        public ActionResult Create()
        {
            return View("Create");
        }



        [HttpPost]
        public ActionResult Create(Categorie categorie)
        {

            if (ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);

        }


      public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }
       
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = db.Categories.Find(id);
            db.Categories.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RefCat,NomCat")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }
        /*
        public void Conction()
        {
            client.BaseAddress = new Uri("http://localhost:59467");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        }
         *     HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IEnumerable<Categorie> listcategorie;
        IEnumerable<Article> listarticles;
         * 
         *  public Categorie  GetCategorie(int id)
        {
            Conction();
            HttpResponseMessage response = client.GetAsync("api/SeulCategorie/" + id).Result;
            return response.Content.ReadAsAsync<Categorie>().Result;
        }
        public ActionResult ModifierEtudiant(Etudiant etudiant)
        {
            Conction();
            var message = client.PutAsJsonAsync("api/Etudiant", etudiant).Result;
            return RedirectToAction("Index");
        }

        // GET: Categories/Details/5
        /* public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Categorie categorie = db.Categories.Find(id);
             if (categorie == null)
             {
                 return HttpNotFound();
             }
             return View(categorie);
         }

         // GET: Categories/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: Categories/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "RefCat,NomCat")] Categorie categorie)
         {
             if (ModelState.IsValid)
             {
                 db.Categories.Add(categorie);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(categorie);
         }

         // GET: Categories/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Categorie categorie = db.Categories.Find(id);
             if (categorie == null)
             {
                 return HttpNotFound();
             }
             return View(categorie);
         }

         // POST: Categories/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "RefCat,NomCat")] Categorie categorie)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(categorie).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(categorie);
         }

         // GET: Categories/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Categorie categorie = db.Categories.Find(id);
             if (categorie == null)
             {
                 return HttpNotFound();
             }
             return View(categorie);
         }

         // POST: Categories/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Categorie categorie = db.Categories.Find(id);
             db.Categories.Remove(categorie);
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
         }*/
    }
}
