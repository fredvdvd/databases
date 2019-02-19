using SkeletonStudent.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonStudent.Data
{
    public class ExersisesQueries
    {
        public static List<Exercise1Model> getSalaryDiff()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT JOB_ID, JOB_TITLE, (max_salary - min_salary) as diff_salary FROM JOBS";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise1Model> data = new List<Exercise1Model>();
            while (dr.Read())
            {
                var JobId = dr["JOB_ID"].ToString();
                var JobTitle = dr["JOB_TITLE"].ToString();
                var VerschilInSalaris = Convert.ToInt32(dr["diff_salary"]); // Zorg hiervoor via het SqlCommand!
                data.Add(new Exercise1Model()
                {
                    JobId = JobId,
                    JobTitle = JobTitle,
                    VerschilInSalaris = VerschilInSalaris
                });
            }

            return data;
        }
        //Toon departmentsnaam en voor departementen met id 1, 5 en 8. 

        public static List<Exercise2Model> Getdepartmentname()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT department_name FROM departments WHERE department_id in ('1','5','8')";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise2Model> data = new List<Exercise2Model>();
            while (dr.Read())
            {
                var DepartmentName = dr["department_name"].ToString();
                // var DepartmentId = Convert.ToInt32(dr["department_ID"]);
                data.Add(new Exercise2Model()
                {
                    DepartmentName = DepartmentName,
                    //DepartmentId = DepartmentId,
                });
            }
            return data;

        }

        public static List<Exercise3Model> GetJobMax10K()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT job_id, REPLACE(job_title,' ','')as trimmedJob FROM jobs WHERE max_salary < 10000";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise3Model> data = new List<Exercise3Model>();
            while (dr.Read())
            {
                var JobTitle = dr["trimmedJob"].ToString();
                var JobId = Convert.ToInt32(dr["job_id"]);
                data.Add(new Exercise3Model()
                {
                    JobTitle = JobTitle,
                    JobId = JobId
                });
            }
            return data;
        }
    }
}
