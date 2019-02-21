using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Business
{
    public class AlbumSummaryService
    {
        public static IList<AlbumSummary> GetAlbumSummariesByGenres(int GenreId)
        {
            //title artist price
            List<AlbumSummary> Albumsum = new List<AlbumSummary>();

            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT ArtistId, Price, Title 
                FROM Album 
                WHERE GenreId = @GenreId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@GenreId", GenreId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int ArtistId = (int)reader["ArtistId"];
                double Price = Convert.ToDouble(reader["Price"]);
                string Title = (string)reader["Title"];
                Albumsum.Add(new AlbumSummary()
                {
                    Artist = ArtistRepository.GetArtistNameById(ArtistId),
                    Price = Convert.ToString(Price)+" $",
                    Title = Title
                });
            }
            reader.Close();
            connection.Close();
            return Albumsum;
        }
    }
}
