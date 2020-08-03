using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Assignment.Models;

namespace Mini_Assignment.Services
{
    public interface ISubjectService
    {
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<IEnumerable<Subject>> GetSubjectListAsync();
        Task<Subject> GetOneSubjectAsync(long id);
        Task<Subject> UpdateSubjectAsync(Subject SubjectToBeUpdated, Subject subject);
        Task<Subject> DeleteSubjectAsync(Subject subject);


    }
}
