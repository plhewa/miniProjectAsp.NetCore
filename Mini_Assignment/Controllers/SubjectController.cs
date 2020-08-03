using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            var subjectObject = await _subjectService.AddSubjectAsync(subject);

            if (subjectObject == null)
            {
                return BadRequest();
            }

            return Ok(subjectObject);
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            IEnumerable<Subject> subjects = await _subjectService.GetSubjectListAsync();

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneSubject(long id)
        {
            var subjectObject = await _subjectService.GetOneSubjectAsync(id);

            if (subjectObject == null)
            {
                return BadRequest("No subject record is found");
            }

            return Ok(subjectObject);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateSubject(long id, Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("subject is null");

            }

            var subjectTobeUpdated = await _subjectService.GetOneSubjectAsync(id);
            if (subjectTobeUpdated == null)
            {
                return BadRequest("No subject record for this id");
            }

            await _subjectService.UpdateSubjectAsync(subjectTobeUpdated, subject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(long id)
        {
            Subject subjectToBeDeleted = await _subjectService.GetOneSubjectAsync(id);

            if(subjectToBeDeleted == null)
            {
                return NotFound("There is a no record !");
            }

            return Ok(_subjectService.DeleteSubjectAsync(subjectToBeDeleted));

        }

    }
}
