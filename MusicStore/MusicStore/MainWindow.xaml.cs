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
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\myapp.txt",
                  rollingInterval: RollingInterval.Day)
                  .CreateLogger();
        }

        private void Oefening1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Oefening1());
        }

        private void allAlbumsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ShowAlbumsPage());
        }

        private void selectAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.SelectAlbumPage());
        }

        private void updateAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.UpdateAlbumsPage());
        }
    }
}
