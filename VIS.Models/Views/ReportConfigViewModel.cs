using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class ReportConfigViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Kalorie { get; set; }
        public bool Nazev { get; set; }
        public bool Meal { get; set; }
        public bool Activity { get; set; }
        public bool Datum { get; set; }
        public bool DaySummary { get; set; }

        public ReportConfigViewModel() { }

        public ReportConfigViewModel(ReportConfigViewModel model)
        {
            From = model.From;
            To = model.To;
            Kalorie = model.Kalorie;
            Nazev = model.Nazev;
            Meal = model.Meal;
            Activity = model.Activity;
            Datum = model.Datum;
            DaySummary = model.DaySummary;
        }

        public ReportConfigViewModel(DateTime from, DateTime to, bool kalorie, bool nazev, bool meal, bool activity, bool date, bool daysum)
        {
            From = from;
            To = to;
            Kalorie = kalorie;
            Nazev = nazev;
            Meal = meal;
            Activity = activity;
            Datum = date;
            DaySummary = daysum;
        }

    }
}
