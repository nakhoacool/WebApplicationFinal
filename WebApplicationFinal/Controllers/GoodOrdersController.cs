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
    public class GoodOrdersController : Controller
    {
        private FinalSE db = new FinalSE();

        public ActionResult Create(string id)
        {
            Good good = db.Goods.Find(id);
            ViewBag.Price = good.SellingPrice;
            ViewBag.Quantity = good.Quantity;
            ViewBag.GName = good.GName;
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName");
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", good.GID);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OID,AID,GID,Quantity,OrderDate,TotalPrice,PaymentMethod")] GoodOrder goodOrder)
        {
            if (ModelState.IsValid)
            {
                db.GoodOrders.Add(goodOrder);
                db.SaveChanges();

                Good good = db.Goods.Find(goodOrder.GID);
                good.Quantity = good.Quantity - goodOrder.Quantity;
                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();

                Random random = new Random();
                char letter = (char)('A' + random.Next(0, 26));
                string deliveryID = "D" + letter + DateTime.Now.ToString("mmss");
                Delivery delivery = new Delivery();
                delivery.DeliveryID = deliveryID;
                delivery.OID = goodOrder.OID;
                delivery.AID = goodOrder.AID;
                delivery.PaymentStatus = "Paid";
                delivery.GoodsStatus = "Pending";

                db.Deliveries.Add(delivery);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", goodOrder.AID);
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", goodOrder.GID);
            return View(goodOrder);
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
