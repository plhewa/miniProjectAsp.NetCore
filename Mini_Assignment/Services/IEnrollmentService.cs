using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Assignment.Models;

namespace Mini_Assignment.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> AssignSubject(Enrollment enrollment);
        Task<bool> ValidStudent(Enrollment enrollment);
        Task<bool> ValidSubject(Enrollment enrollment);
        Task<IEnumerable<Enrollment>> GetEnrollmentList();
    }
}
