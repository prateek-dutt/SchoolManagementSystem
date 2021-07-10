using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Name Must Only Contains Alphabets")]
        public string TeacherName { get; set; }


        public Subject subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public School school { get; set;  }
        [Required]
        public int SchoolId { get; set; }
    }
}
