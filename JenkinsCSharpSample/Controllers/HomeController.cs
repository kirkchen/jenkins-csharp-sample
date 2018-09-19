using JenkinsCSharpSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JenkinsCSharpSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ShoppingCart();
            model.Price = 100;
            model.Qty = 1;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ShoppingCart model)
        {
            var totalPrice = model.Price * model.Qty;
            if (model.MemberType == MemberType.Normal && totalPrice > 1000)
            {
                totalPrice = totalPrice * 0.8m;
            }
            else if (model.MemberType == MemberType.VIP && totalPrice > 500)
            {
                totalPrice = totalPrice * 0.7m;
            }

            model.TotalPrice = totalPrice;

            return View(model);
        }
    }
}