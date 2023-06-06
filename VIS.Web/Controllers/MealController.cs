using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;

namespace VIS.Controllers
{
    [Authorize]
    public class MealController : ControllerBaseBase
    {
        public override string ControllerName => "Meal";

        // GET: Meal
        public ActionResult Index()
        {
            return View();
        }
    }
}