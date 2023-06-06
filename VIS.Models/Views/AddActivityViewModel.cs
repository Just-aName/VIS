using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class AddActivityViewModel : ActivityViewModel
    {
        public int Pocet { get; set; }
        public DateTime Datum { get; set; }

        public AddActivityViewModel() : base() { }

        public AddActivityViewModel(int activity_id, string name, double? cal, bool pub, int user_id, int pocet, DateTime date) :base(activity_id, name, cal, pub, user_id)
        {
            Pocet = pocet;
            Datum = date;
        }
    }
}
