using SkeletonStudent.Data;
using System.Collections.Generic;
using System.Windows;

namespace SkeletonStudent.Exercises
{
    /// <summary>
    /// Interaction logic for Exercise2.xaml
    /// </summary>
    public partial class Exercise2 : Window
    {
        public Exercise2()
        {
            InitializeComponent();
            List<Exercise2Model> data = ExersisesQueries.Getdepartmentname();
            exe2Datagrid.ItemsSource = data;
        }
    }
}
