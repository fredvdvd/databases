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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkeletonStudent
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowExample_Click(object sender, RoutedEventArgs e)
        {
            //Voorbeeld hoe naar een andere pagina te navigeren
            NavigationService.Navigate(new ExamplePage());
        }


        private void SelectExercise1_Click(object sender, RoutedEventArgs e)
        {
            Window exercise1 = new Exercises.Exercise1();
            exercise1.Show();
        }

        private void SelectExercise2_Click(object sender, RoutedEventArgs e)
        {
            Window exercise2 = new Exercises.Exercise2();
            exercise2.Show();
        }


        private void SelectExercise3_Click(object sender, RoutedEventArgs e)
        {
            Window exercise3 = new Exercises.Exercise3();
            exercise3.Show();
        }
        private void SelectExercise7_Click(object sender, RoutedEventArgs e)
        {
            //Voorbeeld hoe een window te openen met een oefening erin
            Window exercise7 = new Exercises.Exercise7();
            exercise7.Show();
        }

    }
}
