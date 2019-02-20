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
        public static IList<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT first_name, last_name, department_id, employee_id FROM Employees";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee empl = new Employee();
                empl.Load(reader);
                employees.Add(empl);
            }

            return employees;
        }


        public static IList<Employee> GetEmployeesByName(string nameToSearch)
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query =
                @"SELECT first_name, last_name, department_id, employee_id 
                FROM Employees
                WHERE first_name LIKE @nameToSearch 
                OR last_name LIKE @nameToSearch";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nameToSearch", "%" + nameToSearch + "%");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee empl = new Employee();
                empl.Load(reader);
                employees.Add(empl);
            }
            connection.Close();
            return employees;
        }

    }
}
