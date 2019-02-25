using MusicStore.Data;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MusicStore.Pages
{
    /// <summary>
    /// Interaction logic for ShowAlbumsPage.xaml
    /// </summary>
    public partial class ShowAlbumsPage : Page
    {
        public ShowAlbumsPage()
        {
            InitializeComponent();
            IList<Album> all_bums = AlbumRepository.GetAllAlbums();
            AllAlbumsGrid.ItemsSource = all_bums;
        }
    }
}
