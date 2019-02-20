using SkeletonStudent.Data;
using System;
using System.Collections;
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
    /// Interaction logic for Exercise8.xaml
    /// </summary>
    public partial class Exercise8 : Window
    {
        public Exercise8()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void UpdateSalary_Click(object sender, RoutedEventArgs e)
        {
            List<Exercise8Model> data = Exercise8queries.GetSalary();
            int UpdatedMinSalary = Convert.ToInt32(MinSalary.Text);
            int UpdatedMaxSalary = Convert.ToInt32(MaxSalary.Text);
            string job = Convert.ToString(JobTitle.Text);

            if (CheckIfJobExists(data, job))
            {
                int rowsAffeccted = Exercise8queries.UpdateSalaryBoundary(job, UpdatedMinSalary, UpdatedMaxSalary);
                MessageBox.Show("it should be updated");
                LoadGrid();
            }
            else
            {
                MessageBox.Show("please enter a valid job");
            }
        }

        private void LoadGrid()
        {
            List<Exercise8Model> data = Exercise8queries.GetSalary();
            Exe8Datagrid.ItemsSource = data;
        }

        private bool CheckIfJobExists(List<Exercise8Model> data, string job)
        {
            bool exists = false;
            foreach (Exercise8Model line in data)
            {
                if(line.JobTitle == job)
                {
                    exists = true;
                }
            }
            return exists;
        }

        private void Exe8Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Exe8Datagrid.SelectedIndex > 0)
            {
                Exercise8Model selectedRow = (Exercise8Model)Exe8Datagrid.SelectedItems[0];
                JobTitle.Text = selectedRow.JobTitle;
                MinSalary.Text = selectedRow.MinSalary.ToString();
                MaxSalary.Text = selectedRow.MaxSalary.ToString();
            }
        }
    }
}
