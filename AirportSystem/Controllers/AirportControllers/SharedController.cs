using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportSystem.Controllers.AirportControllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult _AddSchadule()
        {
            return View();
        }
    }
}