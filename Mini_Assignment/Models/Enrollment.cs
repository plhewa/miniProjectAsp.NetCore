using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Models
{
    public class Enrollment
    {
       
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
