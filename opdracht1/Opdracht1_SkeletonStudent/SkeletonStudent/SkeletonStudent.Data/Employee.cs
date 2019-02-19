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
            FirstName = reader.GetString(reader.GetOrdinal("firstname"));
            LastName = reader.GetString(reader.GetOrdinal("lastName"));
            DepartmentId = reader.GetInt32(reader.GetOrdinal("departmendId"));
            EmployeeId = reader.GetInt32(reader.GetOrdinal("employeeId"));
        }
    }
}
