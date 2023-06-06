using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VIS.Controllers;
using VIS.Models.Views;
using Microsoft.AspNet.Identity;
using VIS.Models.Db;
using VIS.Models.Repositories;
using VIS.App_Start;
using VIS.Models;

namespace VIS.Controllers
{
    [Authorize]
    public class DailyrecordsController : ControllerBaseBase
    {
        private XmlManager Xmlmanager { get; set; } 

        public override string ControllerName => "Dailyrecords";

        public DailyrecordsController(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            Xmlmanager = ServiceInstaller.Get<XmlManager>();
        }

        public DailyrecordsController()
        {
            UnitOfWork = ServiceInstaller.Get<EFUnitOfWork>();
            Xmlmanager = ServiceInstaller.Get<XmlManager>();
        }

        // GET: Dailyrecords
        public ActionResult Index(DateTime? date = null)
        {
            if (date == null)
                date = DateTime.Today;

            ViewBag.Date = date.Value;
            int userId = User.Identity.GetUserId<int>();
            var records = UnitOfWork.DailyrecordsRepository.GetMany(x => x.Datum.Value.Day == date.Value.Day && x.User_ID == userId).ToList();
            var result = new List<DailyrecordsViewModel>();
            foreach(var item in records)
            {
                /*
                MealViewModel meal = null;
                ActivityViewModel activity = null;
                if (item.Meal_id != null)
                {
                    var mealData = UnitOfWork.MealRepository.Get(x => x.Meal_id == item.Meal_id);
                    meal = new MealViewModel(mealData);
                }
                else
                {
                    var activityData = UnitOfWork
                }
                */
                result.Add(new DailyrecordsViewModel(item /*item.Record_id, item.Datum, item.Pocet, item.User_ID, meal, activity*/));
            }
            return View(result);
        }

        public ActionResult AddMeal(DateTime? date = null)
        {
            if (date == null)
                date = DateTime.Today;

            ViewBag.SelectedDate = date.Value;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMeal(AddMealViewModel model)
         {
            var userId = User.Identity.GetUserId<int>();
            var meal = UnitOfWork.MealRepository.Get(x => x.Nazev == model.Nazev && x.User_ID == userId);

            if (meal == null)
            {
                meal = new Meal() { Nazev = model.Nazev, Bilkoviny = model.Bilkoviny, Kalorie = model.Kalorie, Cukry = model.Cukry, Tuky = model.Tuky, Verejne = false, Vlaknina = model.Vlaknina, User_ID = userId};
                UnitOfWork.MealRepository.Add(meal);
            }
            else
            {
                meal.Kalorie = model.Kalorie;
                UnitOfWork.MealRepository.Update(meal);
            }

            var record = new Dailyrecords() { Activity_id = null, Datum = model.Datum, User_ID = userId, Meal_id = meal.Meal_id, Pocet = model.Pocet };
            UnitOfWork.DailyrecordsRepository.Add(record);
            await UnitOfWork.SaveAsync();
            if (model.Verejne)
            {
                //Xmlmanager.AddMeal(meal.Meal_id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddActivity(DateTime? date = null)
        {
            if (date == null)
                date = DateTime.Today;

            ViewBag.SelectedDate = date.Value;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity(AddActivityViewModel model)
        {
            var userId = User.Identity.GetUserId<int>();
            var activity = UnitOfWork.ActivityRepository.Get(x => x.Nazev == model.Nazev && x.User_ID == userId);
            if (activity == null)
            {
                activity = new Activity() { Nazev = model.Nazev, Kalorie = model.Kalorie, Verejne = false, User_ID = userId};
                UnitOfWork.ActivityRepository.Add(activity);
            }
            else
            {
                activity.Kalorie = model.Kalorie;
            }

            var record = new Dailyrecords() { Activity_id = activity.Activity_id, Datum = model.Datum, User_ID = userId, Meal_id = null, Pocet = model.Pocet };
            UnitOfWork.DailyrecordsRepository.Add(record);
            await UnitOfWork.SaveAsync();
            if (model.Verejne)
            {
                //Xmlmanager.AddActivity(activity.Activity_id);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> MealDetail(int meal_id)
        {
            var meal = await UnitOfWork.MealRepository.GetAsync(x => x.Meal_id == meal_id);
            return View(new MealViewModel(meal));
        }

        public async Task<ActionResult> MealEdit(int meal_id)
        {
            var meal = await UnitOfWork.MealRepository.GetAsync(x => x.Meal_id == meal_id);
            return View(new MealViewModel(meal));
        }

        [HttpPost]
        public async Task<ActionResult> MealEdit(MealViewModel model)
        {
            var meal = await UnitOfWork.MealRepository.GetAsync(x => x.Meal_id == model.Meal_id);
            model.UpdateMeal(meal);
            UnitOfWork.MealRepository.Update(meal);
            await UnitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int record_id)
        {
            var record = await UnitOfWork.DailyrecordsRepository.GetAsync(x => x.Record_id == record_id);
            return View(new DailyrecordsViewModel(record));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DailyrecordsViewModel model)
        {
            var record = await UnitOfWork.DailyrecordsRepository.GetAsync(x => x.Record_id== model.Record_id);
            UnitOfWork.DailyrecordsRepository.Delete(record);
            await UnitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ActivityDetail(int activity_id)
        {
            var activity = await UnitOfWork.ActivityRepository.GetAsync(x => x.Activity_id == activity_id);
            return View(new ActivityViewModel(activity));
        }

        public async Task<ActionResult> ActivityEdit(int activity_id)
        {
            var activity = await UnitOfWork.ActivityRepository.GetAsync(x => x.Activity_id == activity_id);
            return View(new ActivityViewModel(activity));
        }

        [HttpPost]
        public async Task<ActionResult> ActivityEdit(ActivityViewModel model)
        {
            var activity = await UnitOfWork.ActivityRepository.GetAsync(x => x.Activity_id == model.Activity_id);
            model.UpdateActivity(activity);
            UnitOfWork.ActivityRepository.Update(activity);
            await UnitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }

        public PartialViewResult SearchMeal(string searchText)
        {
            
            var meals = UnitOfWork.MealRepository.GetMany(x => x.Nazev.Contains(searchText));
            var result = new List<MealViewModel>();
            foreach(var item in meals)
            {
                result.Add(new MealViewModel(item));
            }
            return PartialView("_MealTable", result);
        }
    }
}