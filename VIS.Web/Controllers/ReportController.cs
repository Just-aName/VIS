using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;
using VIS.Models.Views;

namespace VIS.Controllers
{
    [Authorize]
    public class ReportController : ControllerBaseBase
    {
        public override string ControllerName => "Report";

        // GET: Report
        public ActionResult Index()
        {
            return View(new ReportConfigViewModel());
        }

        public ActionResult Generate(ReportConfigViewModel model)
        {
            var result = new ReportDataViewModel(model);
            var userId = User.Identity.GetUserId<int>();
            if(model.Meal)
            {
                var meal = UnitOfWork.DailyrecordsRepository.GetMany(x => x.Datum >= model.From && x.Datum <= model.To && x.User_ID == userId && x.Meal_id != null).ToList();
                foreach(var m in meal)
                {
                    result.MealCollection.Add(new ReportMealDataModel(m.Meal, m?.Datum ?? DateTime.Today));
                }
            }
            if (model.Activity)
            {
                var activity = UnitOfWork.DailyrecordsRepository.GetMany(x => x.Datum >= model.From && x.Datum <= model.To && x.User_ID == userId && x.Activity_id != null).ToList();
                foreach (var a in activity)
                {
                    result.ActivityCollection.Add(new ReportActivityDataModel(a.Activity, a?.Datum ?? DateTime.Today));
                }
            }

            if(model.DaySummary)
            {
                var m = result.MealCollection.GroupBy(x => x.Datum);
                foreach(var item in m)
                {
                    var meal = new ReportSummaryMealModel();
                    meal.Datum = item.Select(x => x.Datum).FirstOrDefault();
                    foreach(var i in item)
                    {
                        meal.AddCount(i);
                    }
                    result.MealSummaryCollection.Add(meal);
                }

                var a = result.ActivityCollection.GroupBy(x => x.Datum);
                foreach (var item in a)
                {
                    var activity = new ReportSummaryActivityModel();
                    activity.Datum = item.Select(x => x.Datum).FirstOrDefault();
                    foreach (var i in item)
                    {
                        activity.AddCount(i);
                    }
                    result.ActivitySummaryCollection.Add(activity);
                }
            }
            return View(result);
        }

    }
}