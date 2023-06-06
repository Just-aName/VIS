using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class ReportViewModel
    {
        public int Report_id { get; set; }
        public string Nazev { get; set; }
        public string Jsonconfig { get; set; }
        public int User_ID { get; set; }
        public Nullable<int> Comment_id { get; set; }

        public ReportViewModel() { }

        public ReportViewModel(int report_id, string name, string json, int user_id, int? comment_id)
        {
            Report_id = report_id;
            Nazev = name;
            Jsonconfig = json;
            User_ID = user_id;
            Comment_id = comment_id;       
        }
    }
}
