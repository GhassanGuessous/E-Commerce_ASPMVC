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
    public class StatistiqueController : ApiController
    {
        public IEnumerable<NumberCommandePerArticle> Get()
        {
            ICommande commande = new ICommandeImpl();
            return commande.GetNumberCommandePerArticle();
        }
    }
}
