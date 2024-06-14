using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfAppPoE3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public class Recipe
    {
        public string Name { get; set; }
        public int NumberOfIngredients { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int NumberOfSteps { get; set; }
        public List<string> Steps { get; set; }
        public double TotalCalories { get; set; }

        public Recipe()
        {
            
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}