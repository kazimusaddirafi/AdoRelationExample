using AdoRelation.Helper;
using AdoRelation.Models;
using System.Data;
using System.Data.SqlClient;

namespace AdoRelation.DAL
{
    public class DepartmentDAL
    {
        string cs= ConnectionString.dbcs;

        public List<Department> GetAlDepartments()
        {
            List<Department> dept=new List<Department>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDepartment",conn);
                cmd.CommandType=CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Department deptInfo = new Department();

                    deptInfo.Id = Convert.ToInt32(reader["ID"]);
                    deptInfo.DepartmentName = reader["DepartmentName"].ToString()??"";
                    dept.Add(deptInfo);
                }
            }

            return dept;
        }

        public void CreateDepartment(Department dept)
        {
            using(SqlConnection conn=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCreateDepartment", conn);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentName", dept.DepartmentName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
