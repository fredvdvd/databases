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
            connection.Close();
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
            connection.Close();
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
            connection.Close();
            return data;
        }

        public static List<Exercise4Model> GetEmployeeManager()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query =
                "WITH manager AS ( SELECT last_name, employee_id from employees )" +
                "SELECT employees.last_name as employeeName, manager.last_name as managerName FROM employees " +
                "LEFT JOIN manager ON employees.manager_id = manager.employee_id";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise4Model> data = new List<Exercise4Model>();
            while (dr.Read())
            {
                string EmployeeName = dr["employeeName"].ToString();
                string ManagerName = dr["managerName"].ToString();
                if (ManagerName == "")
                {
                    ManagerName = "NULL";
                }

                data.Add(new Exercise4Model()
                {
                    EmployeeName = EmployeeName,
                    ManagerName = ManagerName,
                });
            }
            connection.Close();
            return data;
        }

        public static List<Exercise5Model> GetDepartmentHeadCount()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query =
                "select departments.department_id as DepartmentId, COUNT(employee_id) as headcount, departments.department_name as departmentname " +
                "FROM departments " +
                "JOIN employees ON employees.department_id = departments.department_id " +
                "GROUP BY departments.department_name, departments.department_id ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise5Model> data = new List<Exercise5Model>();
            while (dr.Read())
            {
                int DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                int HeadCount = Convert.ToInt32(dr["headcount"]);
                string DepartmentName = dr["departmentname"].ToString();

                data.Add(new Exercise5Model()
                {
                    DepartmentId = DepartmentId,
                    HeadCount = HeadCount,
                    DepartmentName = DepartmentName,
                });
            }
            connection.Close();
            return data;
        }

        public static List<Exercise6Model> GetManagersWith3OrMore()
        {
            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query =
                @"WITH manager AS(SELECT last_name, employee_id from employees ) 
                SELECT manager_id, COUNT(employees.last_name) as Number_Employees, manager.last_name as managerName FROM employees 
                JOIN manager ON employees.manager_id = manager.employee_id 
                GROUP BY manager_id, manager.last_name
                HAVING COUNT(employees.employee_id) > 3";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Exercise6Model> data = new List<Exercise6Model>();
            while (dr.Read())
            {
                int NumberOfEmployees = (int)dr["Number_Employees"];
                int ManagerId = (int)(dr["manager_id"]);
                string ManagerName = (string)dr["managerNAme"];

                data.Add(new Exercise6Model()
                {
                    NumberOfEmployees = NumberOfEmployees,
                    ManagerId = ManagerId,
                    LastName = ManagerName,
                });
            }
            connection.Close();
            return data;
        }
    }
}
