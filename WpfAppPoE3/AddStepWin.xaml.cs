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

namespace WpfAppPoE3
{
    /// <summary>
    /// Interaction logic for AddStepWin.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        private List<string> steps;

        public AddStepWindow(List<string> steps)
        {
            InitializeComponent();
            this.steps = steps;
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            steps.Add(StepDescriptionTextBox.Text);
            MessageBox.Show("Step added successfully!");
            Close();
        }
    }
}