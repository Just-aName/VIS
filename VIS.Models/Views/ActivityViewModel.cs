using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class ActivityViewModel
    {
        public int Activity_id { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public bool Verejne { get; set; }
        public int User_ID { get; set; }

        public ActivityViewModel() { }

        public ActivityViewModel(int activity_id, string name, double? cal, bool pub, int user_id)
        {
            Activity_id = activity_id;
            Nazev = name;
            Kalorie = cal;
            Verejne = pub;
            User_ID = user_id;
        }

        public ActivityViewModel(Activity activity)
        {
            Activity_id = activity.Activity_id;
            Nazev = activity.Nazev;
            Kalorie = activity.Kalorie;
            Verejne = activity?.Verejne ?? false;
            User_ID = activity.User_ID;
        }

        public void UpdateActivity(Activity activity)
        {
            activity.Kalorie = this.Kalorie;
            activity.Nazev = this.Nazev;
        }
    }
}
