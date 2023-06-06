using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class ReportDataViewModel : ReportConfigViewModel
    {

        public List<ReportMealDataModel> MealCollection = new List<ReportMealDataModel>();

        public List<ReportActivityDataModel> ActivityCollection = new List<ReportActivityDataModel>();

        public List<ReportSummaryMealModel> MealSummaryCollection = new List<ReportSummaryMealModel>();

        public List<ReportSummaryActivityModel> ActivitySummaryCollection = new List<ReportSummaryActivityModel>();

        public ReportDataViewModel() : base() { }

        public ReportDataViewModel(DateTime from, DateTime to, bool kalorie, bool nazev, bool meal, bool activity, bool date, bool daysum) : base(from, to, kalorie, nazev, meal, activity, date, daysum)
        {

        }

        public ReportDataViewModel(ReportConfigViewModel model) : base(model)
        {

        }

    }
}
