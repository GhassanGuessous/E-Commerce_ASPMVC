using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Accueil()
        {
            return View();
        }

        public String ConsulterCatalogues()
        {
            return "Consulter les Catalogues";
        }

        public String VisualiserPanier()
        {
            return "Visualiser votre Panier";
        }

        public String Convertisseur()
        {
            return "Convertisseur !";
        }

        public ActionResult LancerCommandes()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Commandes", Action = "Index"}));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Login,MotDePasse")]ClientLogin c)
        {
           if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60076");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var message = client.GetAsync("api/Auth/Login?l="+c.Login+"&m="+c.MotDePasse).Result;

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    Session["ConnecedClientId"] = (message.Content.ReadAsAsync<Client>().Result).NumClient;
                    return View("Accueil");
                }
                    
                else
                {
                    ViewData["erreurAuth"] = "erreurAuth";
                    return View("Index", c);
                }             
            }
           
            return View("Index", c); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription([Bind(Include = "Nom,Prenom,Login,MotDePasse,RetapezMotDePasse,Email,Ville,Tel")]ClientUpdate c)
        {
            if (ModelState.IsValid)
            {
                Client newClient = new Client(c.Login, c.MotDePasse, c.Nom, c.Prenom, c.Email, c.Ville, c.Tel);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60076");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var message = client.GetAsync("api/Auth/Inscription?Login="+newClient.Login+"&MotDePasse="+newClient.MotDePasse+"&Nom="+newClient.Nom+"&Prenom="+newClient.Prenom+"&Email="+newClient.Email+"&Ville="+newClient.Ville+"&Tel="+newClient.Tel).Result;

                if (message.StatusCode == HttpStatusCode.Created)
                {
                    ViewData["bienAjouter"] = "success";
                    return View("Inscription");
                }
                else
                {
                    ViewData["erreurAuth"] = "erreurInscription";
                    return View("Inscription", c);
                }                
            }
            return View("Inscription", c);
        }


        public ActionResult Inscription()
        {
            return View();
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }


        public JsonResult isLoginExists(string Login)
        {
            return Json(!(new E_CommerceContext()).Clients.Any(x => x.Login == Login), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminPanel([Bind(Include = "Login,MotDePasse")]ClientLogin c)
        {
            if (ModelState.IsValid)
            {
                if (c.Login == "admin" && c.MotDePasse == "admin")
                    return RedirectToAction("Index", "Categories");
            }

            ViewData["erreurAuth"] = "erreurAuth";
            return View("Index");
        }
    }
}