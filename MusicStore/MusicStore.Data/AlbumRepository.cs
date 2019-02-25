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
            reader.Close();
            connection.Close();
            return Albums;
        }

        public static IList<Album> GetAllAlbums()
        {
            List<Album> Albums = new List<Album>();

            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT AlbumId, GenreId, ArtistId, Title, Price, AlbumArtUrl 
                FROM Album";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int AlbumId = (int)reader["AlbumId"];
                int GenreId = (int)reader["GenreId"];
                string AlbumArtUrl = (string)reader["AlbumArtUrl"];
                int ArtistId = (int)reader["ArtistId"];
                double Price = Convert.ToDouble(reader["Price"]);
                string Title = (string)reader["Title"];
                Albums.Add(new Album()
                {
                    AlbumId = AlbumId,
                    GenreId = GenreId,
                    AlbumArtUrl = AlbumArtUrl,
                    ArtistId = ArtistId,
                    Price = Price,
                    Title = Title
                });
            }
            reader.Close();
            connection.Close();
            return Albums;
        }

        public static Album GetAlbumById(int albumId)
        {
            Album AlbumById = new Album();
            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT GenreId, ArtistId, Title, Price, AlbumArtUrl 
                FROM Album
                WHERE AlbumId =@albumId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int GenreId = (int)reader["GenreId"];
                string AlbumArtUrl = (string)reader["AlbumArtUrl"];
                int ArtistId = (int)reader["ArtistId"];
                double Price = Convert.ToDouble(reader["Price"]);
                string Title = (string)reader["Title"];
                AlbumById.GenreId = GenreId;
                AlbumById.AlbumArtUrl = AlbumArtUrl;
                AlbumById.ArtistId = ArtistId;
                AlbumById.Price = Price;
                AlbumById.Title = Title;
            }
            reader.Close();
            connection.Close();
            return AlbumById;
        }

        public static void CreateAlbum(Album album)
        {
            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"INSERT INTO Album (GenreId, ArtistId, Title, Price, AlbumArtUrl)
                VALUES (@genreId, @artistId, @title, @price, @albumArtUrl);";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@genreId", album.GenreId);
            cmd.Parameters.AddWithValue("@artistId", album.ArtistId);
            cmd.Parameters.AddWithValue("@title", album.Title);
            cmd.Parameters.AddWithValue("@price", album.Price);
            cmd.Parameters.AddWithValue("@albumArtUrl", album.AlbumArtUrl);
            int rowsUpdated = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateAlbum(Album album)
        {
            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"INSERT INTO Album (GenreId, ArtistId, Title, Price, AlbumArtUrl)
                VALUES (@genreId, @artistId, @title, @price, @albumArtUrl);";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@genreId", album.GenreId);
            cmd.Parameters.AddWithValue("@artistId", album.ArtistId);
            cmd.Parameters.AddWithValue("@title", album.Title);
            cmd.Parameters.AddWithValue("@price", album.Price);
            cmd.Parameters.AddWithValue("@albumArtUrl", album.AlbumArtUrl);
            int rowsUpdated = cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
