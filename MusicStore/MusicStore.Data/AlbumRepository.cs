using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbumsByGenres(int GenreId)
        {
            List<Album> Albums = new List<Album>();

            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query = 
                @"SELECT AlbumId, AlbumArtUrl, ArtistId, Price, Title 
                FROM Album 
                WHERE GenreId = @GenreId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@GenreId", GenreId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int AlbumId = (int)reader["AlbumId"];
                string AlbumArtUrl = (string)reader["AlbumArtUrl"];
                int ArtistId = (int)reader["ArtistId"];
                double Price = Convert.ToDouble(reader["Price"]);
                string Title = (string)reader["Title"];
                Albums.Add(new Album()
                {
                    AlbumId = AlbumId,
                    AlbumArtUrl = AlbumArtUrl,
                    ArtistId = ArtistId,
                    Price = Price,
                    Title = Title
                });
            }
            return Albums;
        }
    }
}
