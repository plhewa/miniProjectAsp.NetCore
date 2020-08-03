using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly StudentDetailContext _context;

        public EnrollmentService(StudentDetailContext studentDetailContext)
        {
            _context = studentDetailContext;
        }
        public async Task<Enrollment> AssignSubject(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }

        public async Task<bool> ValidStudent(Enrollment enrollment)
        {
            var StudentObject = await _context.Students.FirstOrDefaultAsync(s => s.Id == enrollment.StudentId);

            if (StudentObject == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public async Task<bool> ValidSubject(Enrollment enrollment)
        {
            var SubjectObject = await _context.Subjects.FirstOrDefaultAsync(sub => sub.Id == enrollment.SubjectId);

            if (SubjectObject == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentList()
        {
            return await _context.Enrollments.Include(su => su.Subject).Include(st => st.Student).ThenInclude(s => s.Enrollments).ToListAsync();
        }

    }
}
