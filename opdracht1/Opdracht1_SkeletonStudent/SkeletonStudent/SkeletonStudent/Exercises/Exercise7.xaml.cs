using SkeletonStudent.Data;
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

namespace SkeletonStudent.Exercises
{
    /// <summary>
    /// Interaction logic for Oefening7.xaml
    /// </summary>
    public partial class Exercise7 : Window
    {
        public Exercise7()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = MyTextBox.Text;
            if (searchString == null || searchString == "")
            {
                exe7Datagrid.ItemsSource = null;
            }
            else
            {
                IList<Employee> data = ExersisesQueries.GetEmployeesByName(searchString);
                exe7Datagrid.ItemsSource = data;
            }
        }
    }
}
