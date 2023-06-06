using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;

namespace VIS.Controllers
{
    [Authorize]
    public class ActivityController : ControllerBaseBase
    {
        public override string ControllerName => "Activity";

        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }
    }
}