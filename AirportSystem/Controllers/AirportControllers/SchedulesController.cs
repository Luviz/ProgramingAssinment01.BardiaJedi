using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportSystem.Models;

namespace AirportSystem.Controllers.AirportControllers
{
    public class SchedulesController : Controller
    {
        private AirportDBContainer db = new AirportDBContainer();

        // GET: Schedules
        public ActionResult Index()
        {
            var scheduleSet = db.ScheduleSet.Include(s => s.From).Include(s => s.To).Include(s => s.Airplane).Include(s => s.PilotSet).Include(s => s.PilotSet1);
            return View(scheduleSet.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.ScheduleSet.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.FromAirportId = new SelectList(db.Airports, "Id", "Name");
            ViewBag.ToAirportId = new SelectList(db.Airports, "Id", "Name");
            ViewBag.AirplaneRegNumber = new SelectList(db.Airplanes, "RegNumber", "RegNumber");
            ViewBag.PilotId = new SelectList(db.PilotSet, "Id", "FName");
            ViewBag.PilotIdCo = new SelectList(db.PilotSet, "Id", "FName");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightNumber,FromAirportId,ToAirportId,AirplaneRegNumber,PilotId,PilotIdCo,ETA,ETD")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleSet.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromAirportId = new SelectList(db.Airports, "Id", "Name", schedule.FromAirportId);
            ViewBag.ToAirportId = new SelectList(db.Airports, "Id", "Name", schedule.ToAirportId);
            ViewBag.AirplaneRegNumber = new SelectList(db.Airplanes, "RegNumber", "RegNumber", schedule.AirplaneRegNumber);
            ViewBag.PilotId = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotId);
            ViewBag.PilotIdCo = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotIdCo);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.ScheduleSet.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromAirportId = new SelectList(db.Airports, "Id", "Name", schedule.FromAirportId);
            ViewBag.ToAirportId = new SelectList(db.Airports, "Id", "Name", schedule.ToAirportId);
            ViewBag.AirplaneRegNumber = new SelectList(db.Airplanes, "RegNumber", "RegNumber", schedule.AirplaneRegNumber);
            ViewBag.PilotId = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotId);
            ViewBag.PilotIdCo = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotIdCo);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightNumber,FromAirportId,ToAirportId,AirplaneRegNumber,PilotId,PilotIdCo,ETA,ETD")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromAirportId = new SelectList(db.Airports, "Id", "Name", schedule.FromAirportId);
            ViewBag.ToAirportId = new SelectList(db.Airports, "Id", "Name", schedule.ToAirportId);
            ViewBag.AirplaneRegNumber = new SelectList(db.Airplanes, "RegNumber", "RegNumber", schedule.AirplaneRegNumber);
            ViewBag.PilotId = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotId);
            ViewBag.PilotIdCo = new SelectList(db.PilotSet, "Id", "FName", schedule.PilotIdCo);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.ScheduleSet.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.ScheduleSet.Find(id);
            db.ScheduleSet.Remove(schedule);
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
