using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class School
    {
        public int SchoolId { get; set; }

        [Required]

        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Name Must Only Contains Alphabets")]
        public string SchoolName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Name Must Only Contains Alphabets")]
        public string Address { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
