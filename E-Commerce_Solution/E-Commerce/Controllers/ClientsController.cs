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
        /*private E_CommerceContext db = new E_CommerceContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumClient,Login,MotDePasse,Nom,Prenom,Email,Ville,Tel")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumClient,Login,MotDePasse,Nom,Prenom,Email,Ville,Tel")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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

        /******************************Mon code partie client ******************************/



        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IEnumerable<Categorie> listcategorie;
        IEnumerable<Article> listarticles;
        E_CommerceContext db = new E_CommerceContext();
        IEnumerable<MonPanier> article_panier;
        
        
        
         public ActionResult ViewAll()
        {
            return View(GetAllClients());
        }

        IEnumerable<Clients> GetAllClients()
        {
            using (E_CommerceContext db = new E_CommerceContext())
            {
                return db.Clients.ToList<Client>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Client cl = new Client();
            if (id != 0)
            {
                using (E_CommerceContext db = new E_CommerceContext())
                {
                    cl = db.Clients.Where(x => x.NumClient == id).FirstOrDefault<Clients>();
                }
            }
            return View(cl);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Client cl)
        {
           
                using (E_CommerceContext db = new E_CommerceContext())
                {
                    if (cl.NumClient == 0)
                    {
                        db.Clients.Add(cl);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(cl).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllClients()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult Delete(int id)
        {
            
                using (E_CommerceContext db = new E_CommerceContext())
                {
                    Client cl = db.Clients.Where(x => x.NumClient == id).FirstOrDefault<Client>();
                    db.Clients.Remove(cl);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllClients()), message = "Bien supprimé" }, JsonRequestBehavior.AllowGet);
            
        }

        public void Conction()
        {
            client.BaseAddress = new Uri("http://localhost:59467");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        }


        // GET: Client
        public ActionResult Index()
        {
            Conction();
            response = client.GetAsync("api/Categorie").Result;
            listcategorie = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;

            ViewBag.e = new SelectList(listcategorie, "RefCat", "NomCat");
            return View();
        }

        public PartialViewResult AfficheDetails(int value)
        {

            ViewBag.e = value;


            Conction();
            HttpResponseMessage response = client.GetAsync("api/Categorie?id=" + value).Result;
            listarticles = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;

            response = client.GetAsync("api/Categorie").Result;

            return PartialView("_AfficheDetails", listarticles);
        }
        public ActionResult Detail(int id1)
        {
            Conction();
            Article article = new Article();

            HttpResponseMessage response = client.GetAsync("api/Article?id=" + id1).Result;
            article = response.Content.ReadAsAsync<Article>().Result;

            response = client.GetAsync("api/Article").Result;


            return View(article);
        }


        /***SNANA**/

        public ActionResult Index_Panier()
        {
            //if faut mettre  la session de utilisateur à changer  !!!!!!!!!!!

            int id1 = 1;
            Conction();


            HttpResponseMessage response = client.GetAsync("api/Panier?id=" + id1).Result;
            article_panier = response.Content.ReadAsAsync<IEnumerable<MonPanier>>().Result;

            response = client.GetAsync("api/Panier").Result;

            return View(article_panier);


        }




    }
}
