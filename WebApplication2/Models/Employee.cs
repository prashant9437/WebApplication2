using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication2.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }


        //Deatails of Employee
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee? emp = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";

                cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");

                }
                else
                {
                    emp = null;
                    Console.WriteLine("Employee not found!");
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return emp;
        }

        //Index: List of Employees

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> empLst = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.EmpNo = dr.GetInt32("EmpNo");
                    e.Name = dr.GetString("EmpName");
                    e.Basic = dr.GetDecimal("Basic");
                    e.DeptNo = dr.GetInt32("DeptNo");

                    empLst.Add(e);

                }
                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return empLst;
        }
        //Edit TABLE CONTETNT:
        static void Edit(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Employees SET EmpName = @EmpName, Basic = @Basic, DeptNo = @DeptNo,  WHERE EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.EmpName);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


                cmd.ExecuteNonQuery();

                Console.WriteLine("Employee Details Updated Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //Delete:
        static void Delete(int EmpNo)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                try
                {
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

                    cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine("Employee Deleted Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }
}
