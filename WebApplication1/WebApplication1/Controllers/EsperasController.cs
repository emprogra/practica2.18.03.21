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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EsperasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Esperas
        public IQueryable<Espera> GetEsperas()
        {
            return db.Esperas;
        }

        // GET: api/Esperas/5
        [ResponseType(typeof(Espera))]
        public IHttpActionResult GetEspera(string id)
        {
            Espera espera = db.Esperas.Find(id);
            if (espera == null)
            {
                return NotFound();
            }

            return Ok(espera);
        }

        // PUT: api/Esperas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspera(string id, Espera espera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != espera.Nombre)
            {
                return BadRequest();
            }

            db.Entry(espera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EsperaExists(id))
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

        // POST: api/Esperas
        [ResponseType(typeof(Espera))]
        public IHttpActionResult PostEspera(Espera espera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Esperas.Add(espera);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EsperaExists(espera.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = espera.Nombre }, espera);
        }

        // DELETE: api/Esperas/5
        [ResponseType(typeof(Espera))]
        public IHttpActionResult DeleteEspera(string id)
        {
            Espera espera = db.Esperas.Find(id);
            if (espera == null)
            {
                return NotFound();
            }

            db.Esperas.Remove(espera);
            db.SaveChanges();

            return Ok(espera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EsperaExists(string id)
        {
            return db.Esperas.Count(e => e.Nombre == id) > 0;
        }
    }
}