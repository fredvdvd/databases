using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumArtUrl { get; set; }
        public int ArtistId { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}
