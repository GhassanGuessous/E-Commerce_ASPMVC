using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;
using System.Net.Http;

namespace E_Commerce.Controllers
{
    public class ClientsController : Controller
    {

        private E_CommerceContext db = new E_CommerceContext();

        // GET: Clients
        public ActionResult Index(string clientnom, string searchString)
        {
            var nom = new List<string>();

            var y = from d in db.Clients
                    orderby d.Nom
                    select d.Nom;

            nom.AddRange(y.Distinct());

            ViewBag.clientname = new SelectList(nom);

            var cll = from m in db.Clients
                      select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                cll = cll.Where(s => s.Nom.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(clientnom))
            {
                cll = cll.Where(x => x.Prenom == clientnom);
            }

            return View(cll);
        }

        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client cl = db.Clients.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }

//        // GET: Clients/Create
//        public ActionResult Create()
//        {
//            return View();
//        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumClient,Login,MotDePasse,Nom,Prenom,Email,Ville,Tel")] Client cl)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(cl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cl);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client cl = db.Clients.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumClient,Login,MotDePasse,Nom,Prenom,Email,Ville,Tel")] Client cl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cl);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client cl = db.Clients.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client cl = db.Clients.Find(id);
            db.Clients.Remove(cl);
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