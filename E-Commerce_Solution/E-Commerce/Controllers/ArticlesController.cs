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
    
    public class ArticlesController : Controller
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IEnumerable<Categorie> listcategorie;
        IEnumerable<Article> listarticles;


        public void Conction()
        {
            client.BaseAddress = new Uri("http://localhost:59467");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        }
        public Article GetArticle(int id)
        {
            Conction();
            HttpResponseMessage response = client.GetAsync("api/Article/" + id).Result;
            return response.Content.ReadAsAsync<Article>().Result;
        }

        public PartialViewResult  AffichesCategrie(int value)
        {

          //  ViewBag.e = value;


            Conction();
            HttpResponseMessage response = client.GetAsync("api/Categorie?id=" + value).Result;
            listarticles = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;
            ViewBag.etudiant = new SelectList(listarticles, "NumArticle", "Designation");
            return PartialView("_AffichesCategrie", listarticles);
        }
        public PartialViewResult AffichesArticles(int value)
        {
          
            Conction();
            Article article = new Article();

            HttpResponseMessage response = client.GetAsync("api/Article?id=" +value).Result;
            article = response.Content.ReadAsAsync<Article>().Result;
            ViewBag.designation = article.Designation;
            ViewBag.prix= article.PrixU;
            ViewBag.stock = article.Stock;
            ViewBag.photo = article.Photo;
            return PartialView("_AffichesArticles", article);

        }

        public ActionResult Index()
        {
            Conction();
            response = client.GetAsync("api/Categorie").Result;
            listcategorie = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;

            ViewBag.e = new SelectList(listcategorie, "RefCat", "NomCat");
            return View();
        }
        // GET: Articles/Create
        public ActionResult Create()
        {
            Conction();
            response = client.GetAsync("api/Categorie").Result;
            listcategorie = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            ViewBag.RefCat = new SelectList(listcategorie, "RefCat", "NomCat");
            return View();
        }
    





public ActionResult Delete(int id)
        {
           
            Article article = GetArticle(id);
          
            return View(article);
        }

        public ActionResult Edit(int id)
        {
            
            Article article = GetArticle(id);
            //Conction();
            response = client.GetAsync("api/Categorie").Result;
            listcategorie = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            ViewBag.RefCat = new SelectList(listcategorie, "RefCat", "NomCat", article.RefCat);
            return View(article);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Article article)
        {
            Conction();
            var message = client.DeleteAsync("api/DeleteArticle/" + article.NumArticle).Result;
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else { return View(); }
 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumArticle,Designation,PrixU,Stock,Photo,RefCat")] Article article)
        {

            Conction();
            var message = client.PutAsJsonAsync("api/Article", article).Result;
          
                return RedirectToAction("Index");
        
            
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            string physicalPath = "";
            if (file != null) {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string ext = System.IO.Path.GetExtension(file.FileName);
                if (ext == ".jpg" || ext == ".png")
                {
                   physicalPath = Server.MapPath("~/Image/" + ImageName);
                  file.SaveAs(physicalPath);
                    Article article = new Article();
                   article.Designation= Request.Form["Designation"];
                    article.PrixU = Convert.ToDouble(Request.Form["PrixU"]);
                    
                   article.Stock =Convert.ToInt32(Request.Form["Stock"]);
                    article.RefCat= Convert.ToInt32(Request.Form["RefCat"]);
                    article.Photo = ImageName;

                    Conction();
                    var message = client.PostAsJsonAsync("api/Article", article).Result;
                    if (message.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Create");

                    }
                }
                }
            return View("Create");

        }

            /* [HttpPost]
             [ValidateAntiForgeryToken]
             public ActionResult Create([Bind(Include = "NumArticle,Designation,PrixU,Stock,Photo,RefCat")] Article article)
             {


                 Conction();
                 var message = client.PostAsJsonAsync("api/Article", article).Result;
                 if (message.IsSuccessStatusCode)
                 {
                     return RedirectToAction("Index");
                 }
                 else
                 {
                     return View("Create");

                 }



             }
             */

            /* [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "NumArticle,Designation,PrixU,Stock,Photo,RefCat")] Article article)
            {

                    db.Articles.Add(article);
                    db.SaveChanges();
                    return RedirectToAction("Index");
     }*/







            /*private E_CommerceContext db = new E_CommerceContext();

            // GET: Articles


            // GET: Articles/Details/5
            public ActionResult Details(int? id)
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



            // POST: Articles/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


            // GET: Articles/Edit/5
            public ActionResult Edit(int? id)
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
                ViewBag.RefCat = new SelectList(db.Categories, "RefCat", "NomCat", article.RefCat);
                return View(article);
            }

            // POST: Articles/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "NumArticle,Designation,PrixU,Stock,Photo,RefCat")] Article article)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.RefCat = new SelectList(db.Categories, "RefCat", "NomCat", article.RefCat);
                return View(article);
            }

            // GET: Articles/Delete/5
            public ActionResult Delete(int? id)
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

            // POST: Articles/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Article article = db.Articles.Find(id);
                db.Articles.Remove(article);
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
