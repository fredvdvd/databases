using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonStudent.Data
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public void Load(SqlDataReader reader)
        {
            FirstName = reader.GetString(reader.GetOrdinal("first_name"));
            LastName = reader.GetString(reader.GetOrdinal("last_name"));
            DepartmentId = reader.GetInt32(reader.GetOrdinal("department_id"));
            EmployeeId = reader.GetInt32(reader.GetOrdinal("employee_id"));
        }
    }
}
