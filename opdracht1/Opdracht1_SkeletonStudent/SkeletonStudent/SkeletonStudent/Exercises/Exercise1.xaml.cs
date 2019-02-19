using SkeletonStudent.Data;
using System.Collections.Generic;
using System.Windows;

namespace SkeletonStudent.Exercises
{
    /// <summary>
    /// Interaction logic for Exercise.xaml
    /// </summary>
    public partial class Exercise1 : Window
    {
        public Exercise1()
        {
            InitializeComponent();

            List<Exercise1Model> data = ExersisesQueries.getSalaryDiff();
            exe1Datagrid.ItemsSource = data;
        }
    }
}
