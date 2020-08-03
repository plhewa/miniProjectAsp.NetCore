using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Services
{
    public class SubjectService:ISubjectService
    {
        private readonly StudentDetailContext _context;

        public SubjectService(StudentDetailContext context)
        {
            _context = context;
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<IEnumerable<Subject>> GetSubjectListAsync()
        {
            return await _context.Subjects.Include(en => en.Enrollments).ThenInclude(st => st.Student).ToListAsync();
        }

        public async Task<Subject> GetOneSubjectAsync(long id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(sub => sub.Id == id);
        }

        public async Task<Subject> UpdateSubjectAsync(Subject SubjectToBeUpdated, Subject subject)
        {
            SubjectToBeUpdated.Name = subject.Name;

            await _context.SaveChangesAsync();

            return SubjectToBeUpdated;
        }

        public async Task<Subject> DeleteSubjectAsync(Subject subject)
        {
            _context.Remove(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

       

       
    }
}
