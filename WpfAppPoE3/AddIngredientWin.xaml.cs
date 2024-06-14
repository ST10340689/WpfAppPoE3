using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Xml.Linq;
using WpfAppPoE3;


namespace WpfAppPoE3
{
    /// <summary>
    /// Interaction logic for AddIngredientWin.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        private List<Ingredient> ingredients; 
        private Dictionary<string, double> originalQuantities;

        public AddIngredientWindow(List<Ingredient> ingredients, Dictionary<string, double> originalQuantities)
        {
            InitializeComponent(); 
            this.ingredients = ingredients; //Refers to the current instance
            this.originalQuantities = originalQuantities; //Saves original quanitites
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient //Adds new ingredient to recipe
            {
                Name = IngredientNameTextBox.Text, //Name of ingredient
                Quantity = double.Parse(QuantityTextBox.Text), //Quantity of ingredient
                Unit = UnitTextBox.Text, //Unit for ingredient
                Calories = double.Parse(CaloriesTextBox.Text), //Calorie of ingredient
                FoodGroup = FoodGroupTextBox.Text //Food group  of ingredient
            };

            ingredients.Add(ingredient);
            originalQuantities[ingredient.Name] = ingredient.Quantity;
            MessageBox.Show("Ingredient added successfully");
            Close();
        }
    }
}