using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_E_Commerce.Models;

namespace WebAPI_E_Commerce.Service
{
    interface ICommande
    {
       IEnumerable<NumberCommandePerArticle> GetNumberCommandePerArticle();
    }
}
