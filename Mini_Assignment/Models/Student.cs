using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Models
{
    public class Student
    {
       
        public int Id { get; set; }
    
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Addreess { get; set; }
        
        public string MobileNo { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
