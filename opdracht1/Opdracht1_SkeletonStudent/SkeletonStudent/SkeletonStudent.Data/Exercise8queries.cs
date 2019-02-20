using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonStudent.Data
{
    public class Exercise8queries
    {
        //query  to get ALL JOB TITLES + MAX - MIN SALARY
        public static List<Exercise8Model> GetSalary()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT JOB_ID, JOB_TITLE, max_salary, min_salary FROM JOBS";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise8Model> data = new List<Exercise8Model>();
            while (dr.Read())
            {
                var JobTitle = dr["JOB_TITLE"].ToString();
                var MaxSalary = Convert.ToInt32(dr["max_salary"]);
                var MinSalary = Convert.ToInt32(dr["min_salary"]);
                data.Add(new Exercise8Model()
                {
                    JobTitle = JobTitle,
                    MaxSalary = MaxSalary,
                    MinSalary = MinSalary
                });
            }
            connection.Close();
            return data;
        }


        public static int UpdateSalaryBoundary(string Jobtitle, int MinSalary, int MaxSalary)
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string updatesql =
                @"UPDATE jobs
                  SET max_salary = @MaxSalary, min_salary = @MinSalary
                  WHERE job_title = @JobTitle;";

            SqlCommand cmd = new SqlCommand(updatesql, connection);
            cmd.Parameters.AddWithValue("@MaxSalary", MaxSalary);
            cmd.Parameters.AddWithValue("@MinSalary", MinSalary);
            cmd.Parameters.AddWithValue("@JobTitle", Jobtitle);
            int rowsUpdated = cmd.ExecuteNonQuery();            
            connection.Close();           
            return rowsUpdated;
        }
    }
}
