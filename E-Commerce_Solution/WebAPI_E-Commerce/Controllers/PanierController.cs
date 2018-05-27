using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_E_Commerce.Models;
using WebAPI_E_Commerce.Service;

namespace WebAPI_E_Commerce.Controllers
{
    public class PanierController : ApiController
    {
       
            public IEnumerable<MonPanier> Get(int id)
            {

                IEnumerable<MonPanier> articles = new List<MonPanier>();

                IArticle un_article = new ArticleImpl();

                return articles = un_article.Get_Panier(id);

            }

      
    }
}
