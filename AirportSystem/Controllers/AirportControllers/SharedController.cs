using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportSystem.Controllers.AirportControllers {
	public class SharedController : Controller {
		private Models.AirportDBContainer db = new Models.AirportDBContainer();
		// GET: Shared
		public ActionResult _AddSchedule(Models.Schedule s) {
			if (ModelState.IsValid) {
				db.ScheduleSet.Add(s);
				db.SaveChanges();
				return Redirect(Request.UrlReferrer.ToString());
			}
			else {
				return new SchedulesController().Create(s);
			}
		}


		public ActionResult Search(string sQuery) {
			int id = db.Airports.Where(a => a.Name.Equals(sQuery)).FirstOrDefault().Id;
			return RedirectToAction("Details", "Airports",new { id = id });
		}

	}
}