using DataAccess3.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service3.IRepository;
using StudentDepNTier.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet("StudentList")]
        public async Task<IActionResult> Students()
        {
            var studentList =await _student.GetStudentList();
                 return Ok(studentList);
            
        }
        [HttpPost("AddData")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var StudentInfo=await _student.AddStudent(student);
             if(StudentInfo != null)  
                  return Ok(" Added...!");
             return BadRequest("Student Not Added");
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult>DeleteStudent(int id)
        {
            var DeletedData=await _student.DeleteStudent(id);
            if(DeletedData!=null)
                return Ok("Data Is Deleted");
            return BadRequest("Id is wrong");
        }
        [HttpPost("UpdateData")]
        public async Task<IActionResult>UpdateData(Student student)
        {
            var update=await _student.UpdateStudent(student);
            if(update!=null)
                return Ok(update);
            return BadRequest("not found");


        }

    }
}
