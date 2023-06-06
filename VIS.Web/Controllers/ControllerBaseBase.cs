using VIS.Models.Db;
using VIS.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceProcess;
using VIS.Models;

namespace VIS.Controllers
{
    public abstract class ControllerBaseBase : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public abstract string ControllerName { get; }
        public ControllerBaseBase() : base()
        { }

        public ControllerBaseBase(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
    }
}