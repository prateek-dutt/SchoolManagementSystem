using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public ICollection<Teacher > Teachers { get; set; }
    }
}
