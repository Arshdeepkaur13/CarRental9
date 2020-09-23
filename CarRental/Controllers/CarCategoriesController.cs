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
    public class CarCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This  method is used to get category of cars list
        // GET: CarCategories
        public ActionResult Index()
        {
            return View(db.CarCategories.ToList());
        }

        //This  method is used to get category detail of Selected category 
        // GET: CarCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }
        // //This  method is used to update category
        // GET: CarCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        //This  method is used to add category of cars
        // POST: CarCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.CarCategories.Add(carCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carCategory);
        }
        //This api method is used to edit view category of cars
        // GET: CarCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        //This api method is used to update category of cars
        // POST: CarCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carCategory);
        }
        //This api method is used to view delete category of cars
        // GET: CarCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }
        //This api method is used to delete category of cars
        // POST: CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarCategory carCategory = db.CarCategories.Find(id);
            db.CarCategories.Remove(carCategory);
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
