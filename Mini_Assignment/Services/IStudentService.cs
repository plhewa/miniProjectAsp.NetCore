using Mini_Assignment.Models;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mini_Assignment.Services
{
    public interface IStudentService
    {
        Task<Student> CreateStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> UpdateStudentAsync(Student dbEntity, Student entity);
        Task<Student> GetAsync(long id);
        Task<Student> DeleteAsync(Student student);
        Task<bool> ExistanceOfUser(Student student);


    }
}
