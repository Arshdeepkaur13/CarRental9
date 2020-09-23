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
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This  method is used to get car list
        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.CarCategory).Include(c => c.CarType);
            return View(cars.ToList());
        }
        //This  method is used to get car detail
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        //This  method is used to get car view
        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CarCategoryID = new SelectList(db.CarCategories, "ID", "Name");
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "TypeName");
            return View();
        }
        //This  method is used to create car record
        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarName,CarCategoryID,CarTypeID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarCategoryID = new SelectList(db.CarCategories, "ID", "Name", car.CarCategoryID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "TypeName", car.CarTypeID);
            return View(car);
        }
        //this method is used to edit view
        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarCategoryID = new SelectList(db.CarCategories, "ID", "Name", car.CarCategoryID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "TypeName", car.CarTypeID);
            return View(car);
        }
        //this method is used to update car
        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarName,CarCategoryID,CarTypeID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarCategoryID = new SelectList(db.CarCategories, "ID", "Name", car.CarCategoryID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "TypeName", car.CarTypeID);
            return View(car);
        }
      
        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        //this method is used to delete cars
        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
