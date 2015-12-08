using AirportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirportSystem.Controllers.Api {
	public class qualifiedPilotsController : ApiController {

		private AirportDBContainer db = new AirportDBContainer();

		// GET: api/qualifiedPilots
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET: api/qualifiedPilots/5
		public IHttpActionResult Get(int id) {
			var apType = db.AirplaneTypes.Find(id);
			var dbpilots = apType.Pilot_AirPlaneType.Select(p_apt => p_apt.Pilot);
			List<Pilot> pList = new List<Pilot>();
			Dictionary<int, string> ret = new Dictionary<int, string>();
			foreach (var p in dbpilots) {
				ret.Add(p.Id , string.Format("{0}, {1}", p.LName, p.FName ));
			}

			return Ok(ret);
		}

		private class Pilot {
			public int Id { get; set; }
			public string Name { get; set; }

			
		}
	}


}
