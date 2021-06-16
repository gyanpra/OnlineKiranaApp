using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineKirana.Models;

namespace OnlineKirana.Controllers
{
    public class DeliveryAddressController : ApiController
    {
        private OnlineKiranaDbContext db = new OnlineKiranaDbContext();

        // GET: api/DeliveryAddresse
        public List<DeliveryAddress> GetDeliveryAddresses()
        {
            return db.DeliveryAddresses.ToList();
        }

        // GET: api/DeliveryAddresse/5
        [ResponseType(typeof(DeliveryAddress))]
        public async Task<IHttpActionResult> GetDeliveryAddress(int id)
        {
            DeliveryAddress deliveryAddress = await db.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            return Ok(deliveryAddress);
        }

        // PUT: api/DeliveryAddresse/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeliveryAddress(int id, DeliveryAddress deliveryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryAddress.AddressID)
            {
                return BadRequest();
            }

            db.Entry(deliveryAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryAddressExists(id))
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

        // POST: api/DeliveryAddresse
        [ResponseType(typeof(DeliveryAddress))]
        public async Task<IHttpActionResult> PostDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryAddresses.Add(deliveryAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deliveryAddress.AddressID }, deliveryAddress);
        }

        // DELETE: api/DeliveryAddresse/5
        [ResponseType(typeof(DeliveryAddress))]
        public async Task<IHttpActionResult> DeleteDeliveryAddress(int id)
        {
            DeliveryAddress deliveryAddress = await db.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            db.DeliveryAddresses.Remove(deliveryAddress);
            await db.SaveChangesAsync();

            return Ok(deliveryAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryAddressExists(int id)
        {
            return db.DeliveryAddresses.Count(e => e.AddressID == id) > 0;
        }
    }
}