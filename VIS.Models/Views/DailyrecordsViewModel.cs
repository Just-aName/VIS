using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class DailyrecordsViewModel
    {
        public int Record_id { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<double> Pocet { get; set; }
        public int User_ID { get; set; }
        public MealViewModel Meal { get; set; }
        public ActivityViewModel Activity { get; set; }

        public DailyrecordsViewModel() { }

        public DailyrecordsViewModel(int record_id, DateTime? date, double? count, int user_id, MealViewModel meal, ActivityViewModel activity)
        {
            Record_id = record_id;
            Datum = date;
            Pocet = count;
            User_ID = user_id;
            Meal = meal;
            Activity = activity;
        }

        public DailyrecordsViewModel(Dailyrecords records)
        {
            Record_id = records.Record_id;
            Datum = records.Datum;
            Pocet = records.Pocet;
            User_ID = records.User_ID;
            Meal = (records.Meal == null) ? null : new MealViewModel(records.Meal);
            Activity = (records.Activity == null) ? null : new ActivityViewModel(records.Activity);
        }
    }
}
