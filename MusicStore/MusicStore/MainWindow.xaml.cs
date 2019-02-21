using System.Windows.Navigation;
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

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Oefening1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Oefening1());
        }

        private void SelectAlbumButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectAlbumzxButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
