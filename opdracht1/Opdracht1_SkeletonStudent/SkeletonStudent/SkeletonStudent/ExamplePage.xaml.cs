using SkeletonStudent.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ExamplePage.xaml
    /// </summary>
    public partial class ExamplePage : Page
    {
        public ExamplePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnector = CompanyDB.GetConnection())
            {
                /* This code should be in a repository! It just shows how to display
                 * raw data in the UI and can be used as a check if the connection to the 
                 * db  is OK! */
                sqlConnector.Open();
                string query = "SELECT * FROM " + TableCombobox.Text.ToUpper(); // Dangerous, should use input parameter!
                SqlCommand cmd = sqlConnector.CreateCommand();
                cmd.CommandText = query;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dr);

                TableDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
