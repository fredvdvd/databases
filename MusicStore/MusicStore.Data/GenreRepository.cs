using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class GenreRepository
    {
        //vraag Sam nog eens wat een Ilist precies is
        public static IList<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();

            SqlConnection connection = MusicStoreDB.GetConnection();
            connection.Open();
            string query = @"SELECT GenreId, Name, Description FROM Genre";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int GenreId = Convert.ToInt32(reader["GenreId"]);
                string Name = reader["Name"].ToString();
                string Description = reader["Description"].ToString();

                genres.Add(new Genre()
                {
                    GenreId = GenreId,
                    Name = Name,
                    Description = Description
                });
            }
            return genres;
        }




    }
}
