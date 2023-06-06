using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class ReportMealDataModel
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Datum { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public Nullable<double> Bilkoviny { get; set; }
        public Nullable<double> Tuky { get; set; }
        public Nullable<double> Cukry { get; set; }
        public Nullable<double> Vlaknina { get; set; }

        public ReportMealDataModel(Meal meal, DateTime date)
        {
            Nazev = meal.Nazev;
            Kalorie = meal.Kalorie;
            Bilkoviny = meal.Bilkoviny;
            Tuky = meal.Tuky;
            Cukry = meal.Cukry;
            Vlaknina = meal.Vlaknina;
            Datum = date;
        }
    }
}
