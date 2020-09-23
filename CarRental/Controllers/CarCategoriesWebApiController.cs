using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class CarCategoriesWebApiController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //This api method is used to get category of cars list
        // GET: api/CarCategoriesWebApi
        public IQueryable<CarCategory> GetCarCategories()
        {
            return _db.CarCategories;
        }

        //This api method is used to get category detail of Selected category 
        // GET: api/CarCategoriesWebApi/5
        [ResponseType(typeof(CarCategory))]
        public IHttpActionResult GetCarCategory(int id)
        {
            CarCategory carCategory = _db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return Ok(carCategory);
        }

        // //This api method is used to update category
        // PUT: api/CarCategoriesWebApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarCategory(int id, CarCategory carCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carCategory.ID)
            {
                return BadRequest();
            }

            _db.Entry(carCategory).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //This api method is used to add category of cars
        // POST: api/CarCategoriesWebApi
        [ResponseType(typeof(CarCategory))]
        public IHttpActionResult PostCarCategory(CarCategory carCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CarCategories.Add(carCategory);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carCategory.ID }, carCategory);
        }

        //This api method is used to delete category of cars
        // DELETE: api/CarCategoriesWebApi/5
        [ResponseType(typeof(CarCategory))]
        public IHttpActionResult DeleteCarCategory(int id)
        {
            CarCategory carCategory = _db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return NotFound();
            }

            _db.CarCategories.Remove(carCategory);
            _db.SaveChanges();

            return Ok(carCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarCategoryExists(int id)
        {
            return _db.CarCategories.Count(e => e.ID == id) > 0;
        }
    }
}