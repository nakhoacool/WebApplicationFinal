using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Controllers
{
    public class DeliveriesController : Controller
    {
        private FinalSE db = new FinalSE();

        // GET: Deliveries
        public ActionResult Index()
        {
            var deliveries = db.Deliveries.Include(d => d.Agent).Include(d => d.GoodOrder);
            return View(deliveries.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
