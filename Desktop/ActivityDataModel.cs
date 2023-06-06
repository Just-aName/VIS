using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public class ActivityDataModel
    {
        public int Activity_id { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public Nullable<bool> Verejne { get; set; }
        public int User_ID { get; set; }

        public void ModifyActivity(Activity activity)
        {
            activity.Activity_id = this.Activity_id;
            activity.Nazev = this.Nazev;
            activity.Kalorie = this.Kalorie;
            activity.Verejne = this.Verejne;
            activity.User_ID = this.User_ID;
        }

        public ActivityDataModel(DataGridViewRow row)
        {
            Activity_id = (int)row.Cells[0].Value;
            Nazev = (string)row.Cells[1].Value;
            Kalorie = (double?)row.Cells[2].Value;
            Verejne = (bool?)row.Cells[3].Value;
            User_ID = (int)row.Cells[4].Value;
        }

        public ActivityDataModel(Activity activity)
        {
            Activity_id = activity.Activity_id;
            Nazev = activity.Nazev;
            Kalorie = activity.Kalorie;
            Verejne = activity.Verejne;
            User_ID = activity.User_ID;
        }
    }
}
