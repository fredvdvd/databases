using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using SkeletonStudent.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkeletonStudent.Exercises
{
    /// <summary>
    /// Interaction logic for Exercise5.xaml
    /// </summary>
    public partial class Exercise5 : Window
    {
        public Exercise5()
        {
            InitializeComponent();
            List<Exercise5Model> data = ExersisesQueries.GetDepartmentHeadCount();
            exe5Datagrid.ItemsSource = data;
        }
    }
}
