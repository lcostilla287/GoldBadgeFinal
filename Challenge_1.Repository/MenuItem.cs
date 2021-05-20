using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.Repository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string IngredientList { get; set; }
        public double MealPrice { get; set; }

        public MenuItem() { }

        public MenuItem(int mealNumber, string mealName, string description, string ingredientList, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            IngredientList = ingredientList;
            MealPrice = mealPrice;
        }
    }
}
