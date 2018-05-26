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




        public IHttpActionResult PostCategorie(Category categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ICategorie categories = new CategorieImpl();
            categories.AjouterCategorie(categorie);

            return Ok(categorie);

        }
        public IHttpActionResult PutCategorie(Category categorie)
        {
            ICategorie categories = new CategorieImpl();
            categories.ModifierCategorie(categorie);

    
             return Ok(categorie);
        }
        [Route("api/DeleteCategorie/{id}")]
        public IHttpActionResult DeleteCategorie(int  id)
        {
            ICategorie categories = new CategorieImpl();
            categories.SupprimerCategorie(id);


            return Ok();
        }
        [Route("api/SeulCategorie/{id1}")]
        public IHttpActionResult GetCategorie(int id1)
        {

            ICategorie categories = new CategorieImpl();
            Category categorie = new Category();
            categorie=categories.GetCategorie(id1);

            return Ok(categorie);

           

        }
    }
}
