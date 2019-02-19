using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonStudent.Data
{
    public class EmployeeRepository
    {
        public static IList<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            SqlConnection connection = CompanyDB.GetConnection();
            connection.Open();
            string query = "SELECT firstname, lastName, departmendId, employeeId FROM Employee";
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
            // Implementeer hier een search functie voor employees op naam
            // gebruik een input parameter!
            return null;
        }
    }
}
