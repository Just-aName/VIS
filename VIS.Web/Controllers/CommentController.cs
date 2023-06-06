using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;

namespace VIS.Controllers
{
    [Authorize]
    public class CommentController : ControllerBaseBase
    {
        public override string ControllerName => "Comment";

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}