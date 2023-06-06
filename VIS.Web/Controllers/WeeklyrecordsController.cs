using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;

namespace VIS.Controllers
{
    [Authorize]
    public class WeeklyrecordsController : ControllerBaseBase
    {
        public override string ControllerName => "Weeklyrecords";

        // GET: Weeklyrecords
        public ActionResult Index()
        {
            return View();
        }
    }
}