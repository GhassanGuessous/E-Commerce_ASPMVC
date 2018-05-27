using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CurrencyConverterController : Controller
    {
        E_Commerce.CurrencyConverter.ConverterSoapClient proxy = new CurrencyConverter.ConverterSoapClient();

        // GET: CurrencyConverter
        public ActionResult Index()
        {
            ViewBag.c1 = new SelectList(proxy.GetCurrencies().ToList());
            ViewBag.c2 = new SelectList(proxy.GetCurrencies().ToList());
            return View();
        }

        public JsonResult Convert(string cur1, string cur2, decimal montant)
        {
            Decimal res = (Decimal)proxy.GetConversionAmount(cur1, cur2, DateTime.Now, montant);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}