using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class ReportSummaryMealModel
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Datum { get; set; }
        public double Kalorie { get; set; } = 0;
        public double Bilkoviny { get; set; } = 0;
        public double Cukry { get; set; } = 0;
        public double Tuky { get; set; } = 0;
        public double Vlaknina { get; set; } = 0;

        public ReportSummaryMealModel() { }

        public ReportSummaryMealModel(DateTime date, double kal, double bil, double sach, double fat, double vla) 
        {
            Datum = date;
            Kalorie = kal;
            Bilkoviny = bil;
            Cukry = sach;
            Tuky = fat;
            Vlaknina = vla;
        }

        public void AddCount(ReportMealDataModel meal)
        { 
            Kalorie += meal?.Kalorie ?? 0;
            Bilkoviny += meal?.Bilkoviny ?? 0;
            Cukry += meal?.Cukry ?? 0;
            Tuky += meal?.Tuky ?? 0;
            Vlaknina += meal?.Vlaknina ?? 0;
        }
    }
}
