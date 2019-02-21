using System.Collections.Generic;
using System.Windows.Controls;
using MusicStore.Data;
using MusicStore.Business;

namespace MusicStore.Pages
{
    /// <summary>
    /// Interaction logic for Oefening1.xaml
    /// </summary>
    public partial class Oefening1 : Page
    {
        public Oefening1()
        {
            InitializeComponent();
            IList<Genre> listGenres = new List<Genre>();
            listGenres = GenreRepository.GetGenres();
            genreSelector.ItemsSource = listGenres;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genreSelector.SelectedValue == null)
                {
                    return;
                }
            Genre SelectedGenre = (Genre)genreSelector.SelectedValue;
            IList < AlbumSummary > listalbum = AlbumSummaryService.GetAlbumSummariesByGenres(SelectedGenre.GenreId);
            oefening1grid.ItemsSource = listalbum;
        }
    }
}
