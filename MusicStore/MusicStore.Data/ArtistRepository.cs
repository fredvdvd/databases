using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class ArtistRepository
    {
        public static string GetArtistNameById(int artistId)
        {
            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT Name 
                FROM Artist
                WHERE ArtistId = @artistId";
            string nameOfArtist = null;
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@artistId", artistId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nameOfArtist = (string)reader["Name"];
            }
            reader.Close();
            connection.Close();
            return nameOfArtist;
        }

        public static List<Artist> GetAllArtists()
        {
            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT Name, ArtistId
                FROM Artist";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Artist> artistList = new List<Artist>();
            while (reader.Read())
            {
                string artistName = (string)reader["Name"];
                int artistId = Convert.ToInt32(reader["ArtistId"]);
                artistList.Add(new Artist()
                {
                    ArtistId = artistId,
                    Name = artistName
                });
            }
            reader.Close();
            connection.Close();
            return artistList;
        }
    }
}
