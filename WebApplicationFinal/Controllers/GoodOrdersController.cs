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

        // GET: GoodOrders
        public ActionResult Index()
        {
            var goodOrders = db.GoodOrders.Include(g => g.Agent).Include(g => g.Good);
            return View(goodOrders.ToList());
        }

        // GET: GoodOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodOrder goodOrder = db.GoodOrders.Find(id);
            if (goodOrder == null)
            {
                return HttpNotFound();
            }
            return View(goodOrder);
        }

        // GET: GoodOrders/Create
        public ActionResult Create(string id)
        {
            Good good = db.Goods.Find(id);
            ViewBag.Price = good.SellingPrice;
            ViewBag.Quantity = good.Quantity;
            ViewBag.GName = good.GName;
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName");
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", id);
            return View();
        }

        // POST: GoodOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OID,AID,GID,Quantity,OrderDate,TotalPrice,PaymentMethod")] GoodOrder goodOrder)
        {
            if (ModelState.IsValid)
            {
                db.GoodOrders.Add(goodOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", goodOrder.AID);
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", goodOrder.GID);
            return View(goodOrder);
        }

        // GET: GoodOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodOrder goodOrder = db.GoodOrders.Find(id);
            if (goodOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", goodOrder.AID);
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", goodOrder.GID);
            return View(goodOrder);
        }

        // POST: GoodOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OID,AID,GID,Quantity,OrderDate,TotalPrice,PaymentMethod")] GoodOrder goodOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", goodOrder.AID);
            ViewBag.GID = new SelectList(db.Goods, "GID", "GName", goodOrder.GID);
            return View(goodOrder);
        }

        // GET: GoodOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodOrder goodOrder = db.GoodOrders.Find(id);
            if (goodOrder == null)
            {
                return HttpNotFound();
            }
            return View(goodOrder);
        }

        // POST: GoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GoodOrder goodOrder = db.GoodOrders.Find(id);
            db.GoodOrders.Remove(goodOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
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
