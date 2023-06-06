using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Views
{
    public class AddMealViewModel : MealViewModel
    {   
        public int Pocet { get; set; }
        public DateTime Datum { get; set; }

        public AddMealViewModel() : base() { }

        public AddMealViewModel(int meal_id, string name, double? cal, double? bil, double? fat, double? sach, double? vlak, bool pub, int user_id, int pocet, DateTime date) : base(meal_id, name, cal, bil,  fat, sach, vlak, pub, user_id)
        {
            Pocet = pocet;
            Datum = date;
        }
    }
}
