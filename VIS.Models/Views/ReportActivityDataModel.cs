using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class ReportActivityDataModel
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Datum { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }

        public ReportActivityDataModel() { }

        public ReportActivityDataModel(Activity activity, DateTime date)
        {
            Datum = date;
            Nazev = activity.Nazev;
            Kalorie = activity.Kalorie;
        }
    }
}
