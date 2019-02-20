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
    /// Interaction logic for Exercise3.xaml
    /// </summary>
    public partial class Exercise3 : Window
    {
        public Exercise3()
        {
            InitializeComponent();
            List<Exercise3Model> data = ExercisesQueries.GetJobMax10K();
                exe3Datagrid.ItemsSource = data;
        }
    }
}
