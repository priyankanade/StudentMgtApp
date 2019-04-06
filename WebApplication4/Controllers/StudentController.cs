
namespace WebApplication4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
     using WebApplication4.Repository;

    /// <summary>
    /// Student Controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        /// <summary>
        /// The student Data Access class object
        /// </summary>
        private StudentDataAccess studentobj = new StudentDataAccess();

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>returns student model class object</returns>
        [HttpGet]////for retriving data from database
        [Route("getStudent")]
        public IList<StudentModel> GetAllStudent()
        {
            return this.studentobj.GetAllStudent().ToList();
        }

        /// <summary>
        /// Inserts the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        [HttpPost]////for adding data to database
        [Route("add")]
        public StudentModel Insert([FromBody] StudentModel student)
        {
            {
                return this.studentobj.AddStudent(student);
            }

        }

        /// <summary>
        /// Updates the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
     [HttpPut]
        [Route("update")]
        public StudentModel Update([FromBody] StudentModel student)
        {
            return this.studentobj.UpdateStudent(student);
        }

        /// <summary>
        /// Deletes the specified roll no.
        /// </summary>
        /// <param name="RollNo">The roll no.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{RollNo}")]
        public int Delete(int RollNo)
        {
            return this.studentobj.DeleteStudent(RollNo);
        }

    }

}