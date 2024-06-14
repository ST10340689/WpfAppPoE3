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
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private Dictionary<string, double> originalQuantities;
        private Recipe newRecipe;

        public AddRecipeWindow(List<Recipe> recipes, Dictionary<string, double> originalQuantities)
        {
            InitializeComponent();
            this.recipes = recipes; //Refers to current instance of recipe
            this.originalQuantities = originalQuantities;
            newRecipe = new Recipe(); //Calls the new recipe moethod from App.xaml.cs line 22 to 28
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = Convert.ToDouble(QuantityTextBox.Text),
                Unit = UnitTextBox.Text,
                Calories = Convert.ToDouble(CaloriesTextBox.Text),
                FoodGroup = FoodGroupTextBox.Text
            };

            newRecipe.Ingredients.Add(ingredient);
            originalQuantities[ingredient.Name] = ingredient.Quantity;

            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupTextBox.Clear();

            MessageBox.Show("Ingredient added successfully");
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e) //Adding steps
        {
            newRecipe.Steps.Add(StepTextBox.Text);
            StepTextBox.Clear();

            MessageBox.Show("Step added successfully");
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.Name = RecipeNameTextBox.Text;

            newRecipe.TotalCalories = newRecipe.Ingredients.Sum(i => i.Calories * i.Quantity); //Scales the ingredient calorie with the ingredient

            if (newRecipe.TotalCalories > 300)
            {
                MessageBox.Show($"Warning: Total calories for '{newRecipe.Name}' exceeds 300", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning); //Warning for recipe going over 300 calories
            }

            recipes.Add(newRecipe);

            MessageBox.Show("Recipe added successfully");

            Close();
        }
    }
}