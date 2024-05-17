using AdoRelation.Helper;
using AdoRelation.Models;
using System.Data;
using System.Data.SqlClient;

namespace AdoRelation.DAL
{
    public class EmployeeDAL
    {
        string cs= ConnectionString.dbcs;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>();

            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees",conn);
                cmd.CommandType=CommandType.StoredProcedure;
                conn.Open();
              

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Pin = reader["Pin"].ToString() ?? "";
                    emp.Department = new Department
                    {
                        DepartmentName = reader["DepartmentName"].ToString() ?? "",
                        Id = Convert.ToInt32(reader["Id"])
                    };
                    empList.Add(emp);
                }
            }


            return empList;
        }

        public void CreateNewEmployee(Employee employee)
        {

            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spCreateEmployee", conn);
                sqlCommand.CommandType=CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Pin", employee.Pin);
                sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                conn.Open() ;   
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Pin", employee.Pin);
                sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            Employee employee = new Employee();

            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetEmployeeById", conn);
                sqlCommand.CommandType= CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", employeeId);
                conn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read()) {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString()??"";
                    employee.Pin = sqlDataReader["Pin"].ToString() ?? "";
                    employee.Department = new Department
                    {
                        DepartmentName = sqlDataReader["DepartmentName"].ToString() ?? "",
                        Id = Convert.ToInt32(sqlDataReader["Id"])
                    };
                    
                }
            }
            return employee;
        }

        public void DeleteEmploye(int employeeId)
        {
            using(SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployee", connection);
                sqlCommand.CommandType=CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", employeeId);
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
