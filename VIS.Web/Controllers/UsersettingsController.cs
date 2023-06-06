using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIS.Controllers
{
    [Authorize]
    public class UsersettingsController : ControllerBaseBase
    {
        public override string ControllerName => "Usersettings";

        // GET: Usersettings
        public ActionResult Index()
        {
            return View();
        }


    }
}