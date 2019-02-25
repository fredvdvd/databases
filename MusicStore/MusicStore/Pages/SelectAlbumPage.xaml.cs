using MusicStore.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicStore.Pages
{
    /// <summary>
    /// Interaction logic for SelectAlbumPage.xaml
    /// </summary>
    public partial class SelectAlbumPage : Page
    {
        public SelectAlbumPage()
        {
            InitializeComponent();
        }

        private void GetAlbumsButton_Click(object sender, RoutedEventArgs e)
        {
            
            int albumId = Convert.ToInt32(AlbumIdBox.Text);
            

            Album selectedAlbum = new Album();
            selectedAlbum = AlbumRepository.GetAlbumById(albumId);
            if (selectedAlbum.Title == null)
            {
                MessageBox.Show("there is no such album");
            }
            else
            {
                GenreBox.Text = GenreRepository.GetGenreById(selectedAlbum.GenreId).Name;
                ArtistBox.Text = ArtistRepository.GetArtistNameById(selectedAlbum.ArtistId);
                TitleBox.Text = selectedAlbum.Title;
                PriceBox.Text = selectedAlbum.Price.ToString();
                AlbumUrlBox.Text = selectedAlbum.AlbumArtUrl;
            }
        }
    }
}
