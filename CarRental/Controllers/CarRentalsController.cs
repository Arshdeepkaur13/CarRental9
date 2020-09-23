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
    public class CarRentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This  method is used to show car rental list
        // GET: CarRentals
        public ActionResult Index()
        {
            var carRentals = db.CarRentals.Include(c => c.Cars).Include(c => c.Customers);
            return View(carRentals.ToList());
        }
        //This  method is used to show car rental detail of selected car
        // GET: CarRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental.Models.CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        //This  method is used to show car view
        // GET: CarRentals/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            return View();
        }
        //This  method is used to add car rental record
        // POST: CarRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,CarID,IssueDate,DueDate,ReturnDate")] CarRental.Models.CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.CarRentals.Add(carRental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", carRental.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", carRental.CustomerID);
            return View(carRental);
        }

        // GET: CarRentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental.Models.CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", carRental.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", carRental.CustomerID);
            return View(carRental);
        }
        //This  method is used to edit car rental record
        // POST: CarRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,CarID,IssueDate,DueDate,ReturnDate")] CarRental.Models.CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", carRental.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", carRental.CustomerID);
            return View(carRental);
        }
        //This  method is used to delete car rental record
        // GET: CarRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental.Models.CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        // POST: CarRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRental.Models.CarRental carRental = db.CarRentals.Find(id);
            db.CarRentals.Remove(carRental);
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
