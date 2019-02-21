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
            connection.Close();
            return nameOfArtist;
        }
    }
}
