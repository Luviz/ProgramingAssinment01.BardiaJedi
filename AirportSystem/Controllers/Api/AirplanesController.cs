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
using AirportSystem.Models;

namespace AirportSystem.Controllers.Api
{
    public class AirplanesController : ApiController
    {
        private AirportDBContainer db = new AirportDBContainer();

        // GET: api/Airplanes
        public IQueryable<Airplane> GetAirplanes()
        {
            return db.Airplanes;
        }

        // GET: api/Airplanes/5
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult GetAirplane(string id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane.AirplaneTypesId);
        }

        // PUT: api/Airplanes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirplane(string id, Airplane airplane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airplane.RegNumber)
            {
                return BadRequest();
            }

            db.Entry(airplane).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneExists(id))
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

        // POST: api/Airplanes
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult PostAirplane(Airplane airplane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airplanes.Add(airplane);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AirplaneExists(airplane.RegNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = airplane.RegNumber }, airplane);
        }

        // DELETE: api/Airplanes/5
        [ResponseType(typeof(Airplane))]
        public IHttpActionResult DeleteAirplane(string id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return NotFound();
            }

            db.Airplanes.Remove(airplane);
            db.SaveChanges();

            return Ok(airplane);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirplaneExists(string id)
        {
            return db.Airplanes.Count(e => e.RegNumber == id) > 0;
        }
    }
}