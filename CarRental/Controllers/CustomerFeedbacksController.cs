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
    public class CustomerFeedbacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This method is used to get feedback list
        // GET: CustomerFeedbacks
        public ActionResult Index()
        {
            var customerFeedbacks = db.CustomerFeedbacks.Include(c => c.Customer);
            return View(customerFeedbacks.ToList());
        }

        //This method is used to get details of feedback
        // GET: CustomerFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            return View(customerFeedback);
        }

        // GET: CustomerFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            return View();
        }
        //This method is used to create feedback record
        // POST: CustomerFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,Feedback")] CustomerFeedback customerFeedback)
        {
            if (ModelState.IsValid)
            {
                db.CustomerFeedbacks.Add(customerFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerFeedback.CustomerID);
            return View(customerFeedback);
        }

        // GET: CustomerFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerFeedback.CustomerID);
            return View(customerFeedback);
        }
        //This method is used to update record
        // POST: CustomerFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,Feedback")] CustomerFeedback customerFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerFeedback.CustomerID);
            return View(customerFeedback);
        }
        //This method is used to get delete view
        // GET: CustomerFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            return View(customerFeedback);
        }
        //This method is used to delete feedbacks
        // POST: CustomerFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            db.CustomerFeedbacks.Remove(customerFeedback);
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
