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
    public class OrderMasterController : ApiController
    {
        private OnlineKiranaDbContext db = new OnlineKiranaDbContext();

        // GET: api/OrderMaster
        public List<OrderMaster> GetOrderMaster()
        {
            return db.OrderMaster.ToList();
        }

        // GET: api/OrderMaster/5
        [ResponseType(typeof(OrderMaster))]
        public async Task<IHttpActionResult> GetOrderMaster(int id)
        {
            OrderMaster orderMaster = await db.OrderMaster.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            return Ok(orderMaster);
        }

        // PUT: api/OrderMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderMaster(int id, OrderMaster orderMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderMaster.OrderMasterID)
            {
                return BadRequest();
            }

            db.Entry(orderMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMasterExists(id))
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

        // POST: api/OrderMaster
        [ResponseType(typeof(OrderMaster))]
        public async Task<IHttpActionResult> PostOrderMaster(OrderMaster orderMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderMaster.Add(orderMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderMaster.OrderMasterID }, orderMaster);
        }

        // DELETE: api/OrderMaster/5
        [ResponseType(typeof(OrderMaster))]
        public async Task<IHttpActionResult> DeleteOrderMaster(int id)
        {
            OrderMaster orderMaster = await db.OrderMaster.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            db.OrderMaster.Remove(orderMaster);
            await db.SaveChangesAsync();

            return Ok(orderMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderMasterExists(int id)
        {
            return db.OrderMaster.Count(e => e.OrderMasterID == id) > 0;
        }
    }
}