using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class ReportSummaryActivityModel
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Datum { get; set; }
        public double Kalorie { get; set; } = 0;

        public ReportSummaryActivityModel() { }

        public ReportSummaryActivityModel(DateTime date, double cal)
        {
            Datum = date;
            Kalorie = cal;
        }

        public void AddCount(ReportActivityDataModel activity)
        {
            Kalorie += activity?.Kalorie ?? 0;
        }
    }
}
