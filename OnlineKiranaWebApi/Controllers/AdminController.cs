﻿using System;
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
    public class AdminController : ApiController
    {
        private OnlineKiranaDbContext db = new OnlineKiranaDbContext();

        // GET: api/Admins
        public List<Admin> GetAdmin()
        {
            return db.Admin.ToList();
        }

        // GET: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> GetAdmin(int id)
        {
            Admin admin = await db.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.AdminID)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admin.Add(admin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = admin.AdminID }, admin);
        }

        // DELETE: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> DeleteAdmin(int id)
        {
            Admin admin = await db.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admin.Remove(admin);
            await db.SaveChangesAsync();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(int id)
        {
            return db.Admin.Count(e => e.AdminID == id) > 0;
        }
    }
}