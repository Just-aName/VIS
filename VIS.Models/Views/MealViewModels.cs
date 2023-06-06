using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VIS.Models.Db;

namespace VIS.Models.Views
{
    public class MealViewModel
    {
        public int Meal_id { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public Nullable<double> Bilkoviny { get; set; }
        public Nullable<double> Tuky { get; set; }
        public Nullable<double> Cukry { get; set; }
        public Nullable<double> Vlaknina { get; set; }
        public bool Verejne { get; set; }
        public int User_ID { get; set; }

        public MealViewModel() { }

        public MealViewModel(int meal_id, string name, double? cal, double? bil, double? fat, double? sach, double? vlak, bool pub, int user_id)
        {
            Meal_id = meal_id;
            Nazev = name;
            Kalorie = cal;
            Bilkoviny = bil;
            Tuky = fat;
            Cukry = sach;
            Vlaknina = vlak;
            Verejne = pub;
            User_ID = user_id;
        }

        public MealViewModel(Meal meal)
        {
            Meal_id = meal.Meal_id;
            Nazev = meal.Nazev;
            Kalorie = meal.Kalorie;
            Bilkoviny = meal.Bilkoviny;
            Tuky = meal.Tuky;
            Cukry = meal.Cukry;
            Vlaknina = meal.Vlaknina;
            Verejne = meal?.Verejne ?? false;
            User_ID = meal.User_ID;
        }

        public void UpdateMeal(Meal meal)
        {
            meal.Kalorie = this.Kalorie;
            meal.Nazev = this.Nazev;
            meal.Tuky = this.Tuky;
            meal.Vlaknina = this.Vlaknina;
            meal.Cukry = this.Cukry;
            meal.Bilkoviny = this.Bilkoviny;
        }
    }
}