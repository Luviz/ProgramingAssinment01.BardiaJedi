using AirportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AirportSystem.Controllers.Api {
	public class qualifiedPilotsController : ApiController {

		private AirportDBContainer db = new AirportDBContainer();
		
		// GET: api/qualifiedPilots/ABC123
		public IHttpActionResult Get(string id) {
			Dictionary<int, string> ret = new Dictionary<int, string>();

			int type = db.Airplanes.Find(id).AirplaneTypesId;

			db.AirplaneTypes
				.Find(type).Pilot_AirPlaneType
				.Select(p_apt => p_apt.Pilot).ToList()
				.ForEach(p => ret.Add(p.Id, string.Format("{0}, {1}", p.LName, p.FName)));

			if (ret.Any())
				return Ok(ret);
			else
				return BadRequest();
		}

	}


}
