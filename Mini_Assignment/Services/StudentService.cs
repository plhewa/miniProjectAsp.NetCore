using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDetailContext _context;
        public StudentService(StudentDetailContext context)
        {
            _context = context;

        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;

        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(e => e.Enrollments).ThenInclude(s => s.Subject).ToListAsync();
        }

        public async Task<Student> UpdateStudentAsync(Student student , Student entity)
        {
            student.MobileNo = entity.MobileNo;
            student.Password = entity.Password;
            student.Addreess = entity.Addreess;

          await _context.SaveChangesAsync();

           return student;


        }

        public async Task<Student> GetAsync(long id)
        {

            return await _context.Students
                    .FirstOrDefaultAsync(st => st.Id == id);

        }

        public async Task<Student> DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }
        public async Task<bool> ExistanceOfUser(Student student)
        {
            Student existantStudent = await _context.Students.FirstOrDefaultAsync(st => st.UserName == student.UserName);

            if (existantStudent == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

    }
}
