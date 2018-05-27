using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    interface IArticle
    {
      
            Article GetArticle(int id);
            IEnumerable<MonPanier> Get_Panier(int id);
      
    }
}
