using AspNetWebApi.Entites;
using AspNetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        UrunDbContext db = new UrunDbContext();
        public IQueryable<Products> GetProduct()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult GetProduct(int id)
        {
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProduct(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(products);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new {id=products.Id},products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(Products))]

        public IHttpActionResult PutProducts(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(products).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products==null)
            {
                return NotFound();
            }
            db.Products.Remove(products);
            db.SaveChanges();
            return Ok(products);
        }
    }
}
