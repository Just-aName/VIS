using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public class MealDataModel
    {
        public int Meal_id { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public Nullable<double> Bilkoviny { get; set; }
        public Nullable<double> Tuky { get; set; }
        public Nullable<double> Cukry { get; set; }
        public Nullable<double> Vlaknina { get; set; }
        public Nullable<bool> Verejne { get; set; }
        public int User_ID { get; set; }

        public void ModifyMeal(Meal meal)
        {
            meal.Meal_id = this.Meal_id;
            meal.Nazev = this.Nazev;
            meal.Kalorie = this.Kalorie;
            meal.Bilkoviny = this.Bilkoviny;
            meal.Tuky = this.Tuky;
            meal.Cukry = this.Cukry;
            meal.Vlaknina = this.Vlaknina;
            meal.Verejne = this.Verejne;
            meal.User_ID = this.User_ID;
        }

        public MealDataModel(DataGridViewRow row)
        {
            Meal_id = (int)row.Cells[0].Value;
            Nazev = (string)row.Cells[1].Value;
            Kalorie = (double?)row.Cells[2].Value;
            Bilkoviny = (double?)row.Cells[3].Value;
            Tuky= (double?)row.Cells[4].Value;
            Cukry = (double?)row.Cells[5].Value;
            Vlaknina = (double?)row.Cells[6].Value;
            Verejne = (bool?)row.Cells[7].Value;
            User_ID= (int)row.Cells[8].Value;
        }

        public MealDataModel(Meal meal)
        {
            Meal_id = meal.Meal_id;
            Nazev = meal.Nazev;
            Kalorie = meal.Kalorie;
            Bilkoviny = meal.Bilkoviny;
            Tuky = meal.Tuky;
            Cukry = meal.Cukry;
            Vlaknina = meal.Vlaknina;
            Verejne = meal.Verejne;
            User_ID = meal.User_ID;
        }
    }
}
