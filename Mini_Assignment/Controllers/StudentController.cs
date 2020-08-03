using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Models;
using Mini_Assignment.Services;

namespace Mini_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (await _studentService.ExistanceOfUser(student))
            {
                return BadRequest("This user is already exist");
            }

            var studentObject = await _studentService.CreateStudentAsync(student);

            if (studentObject == null)
            {
                return BadRequest("This user is null");
            }


            return Ok(studentObject);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            IEnumerable<Student> Students = await _studentService.GetAllStudentsAsync();

            return Ok(Students);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(long id,Student student)

        {
            if (student == null)

            {
                return BadRequest("Student is null.");
            }

            Student studentToUpdate = await _studentService.GetAsync(id);
            if (studentToUpdate == null)
            {
                return NotFound("The Student record couldn't be found.");
            }

            await _studentService.UpdateStudentAsync(studentToUpdate, student);

            return NoContent();


        }
      
        [HttpGet("{id}")]

        public async Task<IActionResult> GetOneStudent(long id) 

        {
            Student student =await _studentService.GetAsync(id);


            if (student == null)
            {
                return NotFound("The Student record couldn't be found.");
            }

            return Ok(student);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            Student student = await _studentService.GetAsync(id);

            if (student == null)
            {

                return NotFound("The student record couldn't be found.");

            }

            return Ok(_studentService.DeleteAsync(student));
        }

    
    }
}
