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
    public class CategorieController : ApiController
    {
       
            /*  BD_ASPMVCEntities db = new BD_ASPMVCEntities();
              public IEnumerable<Categorie> Get()
              {

                  return db.Categories.ToList();
              }
              */
            public IEnumerable<Category> Get()
            {
                ICategorie categorie = new CategorieImpl();
                return categorie.AllCategorie();
            }
            public IHttpActionResult Get(int id)
            {

                IEnumerable<Article> articles = new List<Article>();

                ICategorie categorie = new CategorieImpl();

                articles = categorie.AllArticle(id);
                if (articles == null)
                {

                    return NotFound();
                }
                return Ok(articles);
            }






        }
    }
