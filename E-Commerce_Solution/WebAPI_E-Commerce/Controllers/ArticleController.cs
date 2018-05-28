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
    public class ArticleController : ApiController
    {
      

        public IHttpActionResult Get(int id)
        {
            IArticle article = new ArticleImpl();
            Article articles = new Article();
            articles = article.GetArticle(id);
            if (articles == null)
            {

                return NotFound();
            }
            return Ok(articles);
        }

        public IHttpActionResult PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IArticle articles= new  ArticleImpl();
            articles.AjouterArticle(article);
return Ok(article);

        }
        public IHttpActionResult PutArticle(Article article)
        {
            IArticle articles = new ArticleImpl();
            articles.ModifierArticle(article);

            return Ok(article);
        }
        [Route("api/DeleteArticle/{id}")]
        public IHttpActionResult DeleteCategorie(int id)
        {
            IArticle articles = new ArticleImpl();
            articles.SupprimerArticlee(id);
      


            return Ok();
        }
    }
}
