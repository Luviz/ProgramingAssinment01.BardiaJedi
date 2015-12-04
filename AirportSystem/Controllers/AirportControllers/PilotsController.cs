using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportSystem.Models;

namespace AirportSystem.Controllers.AirportControllers {
	public class PilotsController : Controller {
		private AirportDBContainer db = new AirportDBContainer();

		// GET: Pilots
		public ActionResult Index() {
			var pilotSet = db.PilotSet.Include(p => p.City);
			return View(pilotSet.ToList());
		}

		// GET: Pilots/Details/5
		public ActionResult Details(int? id) {
			if (id == null) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Pilot pilot = db.PilotSet.Find(id);
			if (pilot == null) {
				return HttpNotFound();
			}

			ViewBag.licensesAvailable = db.AirplaneTypes
				.Where(at => !at.Pilot_AirPlaneType
					.Select(x => x.PilotId).ToList()
					.Contains(pilot.Id)).OrderBy(at => at.Type);

			return View(pilot);
		}

		// GET: Pilots/Create
		public ActionResult Create() {
			ViewBag.CityId = new SelectList(db.Citys, "Id", "Name");
			return View();
		}

		// POST: Pilots/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,FName,LName,CityId")] Pilot pilot) {
			if (ModelState.IsValid) {
				db.PilotSet.Add(pilot);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", pilot.CityId);
			return View(pilot);
		}

		// GET: Pilots/Edit/5
		public ActionResult Edit(int? id) {
			if (id == null) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Pilot pilot = db.PilotSet.Find(id);
			if (pilot == null) {
				return HttpNotFound();
			}
			ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", pilot.CityId);
			return View(pilot);
		}

		// POST: Pilots/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,FName,LName,CityId")] Pilot pilot) {
			if (ModelState.IsValid) {
				db.Entry(pilot).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", pilot.CityId);
			return View(pilot);
		}

		// GET: Pilots/Delete/5
		public ActionResult Delete(int? id) {
			if (id == null) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Pilot pilot = db.PilotSet.Find(id);
			if (pilot == null) {
				return HttpNotFound();
			}
			return View(pilot);
		}

		// POST: Pilots/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id) {
			Pilot pilot = db.PilotSet.Find(id);
			db.PilotSet.Remove(pilot);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult AddLicense(string license, int? id) {
			if (id.HasValue || string.IsNullOrWhiteSpace(license)) { //??
				db.Pilot_AirPlaneTypeSet.Add(new Pilot_AirPlaneType {
					PilotId = id.Value,
					AirplaneTypesId = db.AirplaneTypes.Where(at => at.Type.Equals(license)).Select(at => at.Id).FirstOrDefault()
				});
				db.SaveChanges(); 
			}
			return RedirectToAction("Details/"+id.ToString());
		}

		public ActionResult RemLicenese(int? id) {
			db.Pilot_AirPlaneTypeSet.Remove(db.Pilot_AirPlaneTypeSet.Find(id));
			db.SaveChanges();
			return Redirect(Request.UrlReferrer.ToString());			
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
