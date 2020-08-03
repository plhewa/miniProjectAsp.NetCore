using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Models
{
    public class Subject
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
