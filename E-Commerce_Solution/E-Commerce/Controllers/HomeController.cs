using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public String LancerCommandes()
        {
            return "Lancer des Commandes";
        }

        public ActionResult Login()
        {
            return RedirectToAction("Accueil");
        }

        public String Inscription()
        {
            return "Nouvelle Inscription !";
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}