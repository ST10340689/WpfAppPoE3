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
    public partial class ScaleRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private Dictionary<string, double> originalQuantities;

        public ScaleRecipeWindow(List<Recipe> recipes, Dictionary<string, double> originalQuantities)
        {
            InitializeComponent();
            this.recipes = recipes;
            this.originalQuantities = originalQuantities;
            RecipeComboBox.ItemsSource = recipes;
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem is Recipe selectedRecipe)
            {
                if (ScaleFactorComboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    double scale = Convert.ToDouble(selectedItem.Content);

                    foreach (var ingredient in selectedRecipe.Ingredients)
                    {
                        ingredient.Quantity = originalQuantities[ingredient.Name] * scale;
                    }

                    selectedRecipe.TotalCalories *= scale;

                    MessageBox.Show($"Recipe '{selectedRecipe.Name}' scaled by a factor of {scale} successfully!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Please select a scaling factor.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }
    }
}