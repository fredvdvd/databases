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
    /// Interaction logic for Exercise6.xaml
    /// </summary>
    public partial class Exercise6 : Window
    {
        public Exercise6()
        {
            InitializeComponent();
            List<Exercise6Model> data = ExercisesQueries.GetManagersWith3OrMore();
            exe6Datagrid.ItemsSource = data;
        }
    }
}
