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
    /// Interaction logic for UpdateAlbumsPage.xaml
    /// </summary>
    public partial class UpdateAlbumsPage : Page
    {
        public UpdateAlbumsPage()
        {
            InitializeComponent();

            IList<Genre> genreList = new List<Genre>();
            genreList = GenreRepository.GetGenres();
            GenreCombo.ItemsSource = genreList;
            List<Artist> ArtistList = new List<Artist>();
            ArtistList = ArtistRepository.GetAllArtists();
            ArtistCombo.ItemsSource = ArtistList;
        }

        private List<int> GetAlbumIdList()
        {
            IList<Album> AlbumList = new List<Album>();
            List<int> IdList = new List<int>();
            AlbumList = AlbumRepository.GetAllAlbums();
            foreach (Album album in AlbumList)
            {
                IdList.Add(album.AlbumId);
            }
            return IdList;
        }
        private bool IdInListCheck(int albumId)
        {
            bool check = false;
            List<int> idList = GetAlbumIdList();
            foreach(int id in idList)
            {
                if(albumId == id)
                {
                    check = true;
                }
            }
            return check;
        }

        private void AlbumIdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(AlbumIdBox == null|| getAlbumButton == null)
            {

            }
            else
            {
                int id = IntputHandling();
                if (IdInListCheck(id))
                {
                    getAlbumButton.IsEnabled = true;
                }
                else
                {
                    getAlbumButton.IsEnabled = false;
                }
            }

        }

        private void GetAlbumButton_Click_1(object sender, RoutedEventArgs e)
        {
            int id = IntputHandling();
            Album selectedAlbum = new Album();
            selectedAlbum = AlbumRepository.GetAlbumById(id);
            GenreCombo.Text = GenreRepository.GetGenreById(selectedAlbum.GenreId).Name;
            ArtistCombo.Text = ArtistRepository.GetArtistNameById(selectedAlbum.ArtistId);
            TitleBox.Text = selectedAlbum.Title;
            PriceBox.Text = selectedAlbum.Price.ToString();
            AlbumUrlBox.Text = selectedAlbum.AlbumArtUrl;
        }

        private int IntputHandling()
        {
            try
            {
                int id = Convert.ToInt32(AlbumIdBox.Text);
                return id;
            }
            catch (FormatException invalidInputExeption)
            {
                MessageBox.Show(invalidInputExeption.Message);
                return 0;
            }
        }

        private void UpdateAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            Album updatedAlbum = new Album();
            updatedAlbum = SetValues();
            if (IdInListCheck(updatedAlbum.AlbumId))
            {
                //set
            }
            else
            {
                AlbumRepository.CreateAlbum(updatedAlbum);
                MessageBox.Show("new item created");
            }
        }

        private Album SetValues()
        {
            Album setAlbum = new Album();
            setAlbum.Title = TitleBox.Text;
            setAlbum.Price = Convert.ToDouble(PriceBox.Text);
            if (AlbumUrlBox.Text == "")
            {
                setAlbum.AlbumArtUrl = null;
            }
            else 
            {
                setAlbum.AlbumArtUrl = AlbumUrlBox.Text;
            }
            if (AlbumIdBox.Text != "")
            {
                setAlbum.AlbumId = Convert.ToInt32(AlbumIdBox.Text);
            }

            if (GenreCombo.SelectedValue != null)
            {
                Genre genre = (Genre)GenreCombo.SelectedValue;
                setAlbum.GenreId = genre.GenreId;
            }
            if (ArtistCombo.SelectedValue != null)
            {
                Artist artist = (Artist)ArtistCombo.SelectedValue;
                setAlbum.ArtistId = artist.ArtistId;  
            }
            return setAlbum;
        }
    }
}
