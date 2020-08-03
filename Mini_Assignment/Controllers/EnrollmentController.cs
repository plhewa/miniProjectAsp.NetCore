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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }


        [HttpPost]

        public async Task<IActionResult> AssignSubject(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Enrollment is null");
            }
            else if (!await _enrollmentService.ValidStudent(enrollment))
            {
                return BadRequest("Invalid Student");
            }

            else if (!await _enrollmentService.ValidSubject(enrollment))
            {
                return BadRequest("Invalid Subject");
            }
            else
            {
                var enrollmentObject = await _enrollmentService.AssignSubject(enrollment);

                return Ok(enrollmentObject);
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollmentList()
        {
            IEnumerable<Enrollment> enrollments = await _enrollmentService.GetEnrollmentList();

            return Ok(enrollments);
        }

       
    }
}
