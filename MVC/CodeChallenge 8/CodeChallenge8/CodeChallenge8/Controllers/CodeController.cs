using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeChallenge8;
using CodeChallenge8.Models;

namespace MVC_CodeChallange_1.Controllers
{

    public class CodeController : Controller
    {
        private northwindEntities db = new northwindEntities();


        public ActionResult CustomersList()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }
     
        public ActionResult CustomerByOrderId()
        {
            int orderId = 10248;
            var customerDetails = db.Customers
                                     .Where(c => c.Orders.Any(o => o.OrderID == orderId))
                                     .FirstOrDefault();
            return View(customerDetails);
        }

    }
}