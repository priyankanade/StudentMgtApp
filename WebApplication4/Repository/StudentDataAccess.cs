using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication4.Repository
{
    public class StudentDataAccess
    {
        string connectionString = "data source=(localDB)\\Local; Database=Student; integrated security=SSPI;";
        //To View all employees details              
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public IList<StudentModel> GetAllStudent()
        {

            List<StudentModel> liststudent = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spviewquery", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.RollNo = Convert.ToInt32(rdr["RollNo"]);
                        student.Name = rdr["Name"].ToString();
                        student.Age = Convert.ToInt32(rdr["Age"]);
                        student.City = rdr["City"].ToString();
                        student.Course = rdr["Course"].ToString();
                        liststudent.Add(student);
                    }
                     
                    con.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("", e.Message);
                }
            }
            return liststudent;
        }
        /// <summary>
        /// Adds the student.
        /// </summary>
        /// <param name="student">The student.</param>              
        public StudentModel AddStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spinsertquery", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RollNo", student.RollNo);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@Course", student.Course);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return student;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        public StudentModel UpdateStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spupdatequery", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RollNo", student.RollNo);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@Course", student.Course);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return student;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
       
        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public int DeleteStudent(int? RollNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spdeletequery", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RollNo", RollNo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception (e.Message);
                }
            }
        }
    }
}

