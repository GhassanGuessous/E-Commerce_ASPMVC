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
        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IEnumerable<Categorie> listcategorie;
        IEnumerable<Article> listarticles;
        public ActionResult Index()
        {
            return View();
        }
        public void Conction()
        {
            client.BaseAddress = new Uri("http://localhost:59467");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        }
        public JsonResult GetData()
            {
            Conction();
           IEnumerable<NumberCommandePerArticle> Details = new List<NumberCommandePerArticle>();
            response = client.GetAsync("api/Statistique").Result;
            Details = response.Content.ReadAsAsync<IEnumerable<NumberCommandePerArticle>>().Result;

         
            return Json(Details, JsonRequestBehavior.AllowGet);
            }


        }
    }
