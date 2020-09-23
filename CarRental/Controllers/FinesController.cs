using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class FinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This method is used to get fine list
        // GET: Fines
        public ActionResult Index()
        {
            var fines = db.Fines.Include(f => f.CarRentals);
            return View(fines.ToList());
        }

        //This method is used to get details of fine
        // GET: Fines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine fine = db.Fines.Find(id);
            if (fine == null)
            {
                return HttpNotFound();
            }
            return View(fine);
        }

        // GET: Fines/Create
        public ActionResult Create()
        {
            ViewBag.CarRentalID = new SelectList(db.CarRentals, "ID", "ID");
            return View();
        }
        //This method is used to create fine
        // POST: Fines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarRentalID,AmountFine,FineDeposit,DepositDate")] Fine fine)
        {
            if (ModelState.IsValid)
            {
                db.Fines.Add(fine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarRentalID = new SelectList(db.CarRentals, "ID", "ID", fine.CarRentalID);
            return View(fine);
        }

        // GET: Fines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine fine = db.Fines.Find(id);
            if (fine == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarRentalID = new SelectList(db.CarRentals, "ID", "ID", fine.CarRentalID);
            return View(fine);
        }

        //This method is used to update fine
        // POST: Fines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarRentalID,AmountFine,FineDeposit,DepositDate")] Fine fine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarRentalID = new SelectList(db.CarRentals, "ID", "ID", fine.CarRentalID);
            return View(fine);
        }

        // GET: Fines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine fine = db.Fines.Find(id);
            if (fine == null)
            {
                return HttpNotFound();
            }
            return View(fine);
        }
        //This method is used to delete fine
        // POST: Fines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fine fine = db.Fines.Find(id);
            db.Fines.Remove(fine);
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
