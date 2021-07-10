using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class SchoolDbInit
    {
        private readonly ApplicationDbContext _db;

        public SchoolDbInit(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Seed()
        {
            if(!_db.Schools.Any())
            {
                _db.AddRange(_sample);
                 _db.SaveChanges();
            }
        }

        List<School> _sample = new List<School>
        {
            new School()
            {
                SchoolName="Scottish Public School",
                 Address ="Pragati Path, Katihar",
                 Teachers = new List<Teacher>{
                     new Teacher()
                     {
                     TeacherName="Shailendra Verma",
                     subject= new Subject()
                     {
                         SubjectName="History"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Pallav Ghosh",
                     subject= new Subject()
                     {
                         SubjectName="Mathematics"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Vijay Raj",
                     subject= new Subject()
                     {
                         SubjectName="Hindi"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Khushboo Bhopalka",
                     subject= new Subject()
                     {
                         SubjectName="English"
                     }
                     },


                }


            },
            new School()
            {
                SchoolName="Don Bosco Public",
                 Address ="Mahant Nagar, Katihar",
                 Teachers = new List<Teacher>{
                     new Teacher()
                     {
                     TeacherName="Raj Verma",
                     subject= new Subject()
                     {
                         SubjectName="Physics"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Ray Jay",
                     subject= new Subject()
                     {
                         SubjectName="Chemistry"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="V Raj",
                     subject= new Subject()
                     {
                         SubjectName="Sanskrit"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Khusal",
                     subject= new Subject()
                     {
                         SubjectName="Social Sciences"
                     }
                     },


                }


            },

                        new School()
            {
                SchoolName="SBP VIDYA VIHAR",
                 Address ="Purnia Highway, Katihar",
                 Teachers = new List<Teacher>{
                     new Teacher()
                     {
                     TeacherName="Shailendra V",
                     subject= new Subject()
                     {
                         SubjectName="Geography"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Tim Dillon",
                     subject= new Subject()
                     {
                         SubjectName="Civics"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Ray Jason",
                     subject= new Subject()
                     {
                         SubjectName="Econonomy"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Pam Ray",
                     subject= new Subject()
                     {
                         SubjectName="Paintings"
                     }
                     },


                }


            },

                        new School()
            {
                SchoolName="G.D GOENKA PUBLIC SCHOOL",
                 Address ="Manihari Road, Katihar",
                 Teachers = new List<Teacher>{
                     new Teacher()
                     {
                     TeacherName="Jim Parker",
                     subject= new Subject()
                     {
                         SubjectName="Biology"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Ben Arkson",
                     subject= new Subject()
                     {
                         SubjectName="Computer"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Phyllis Adison",
                     subject= new Subject()
                     {
                         SubjectName="Home Science"
                     }
                     },
                     new Teacher()
                     {
                     TeacherName="Dwight Shrute",
                     subject= new Subject()
                     {
                         SubjectName="Literature"
                     }
                     },


                }


            },




        };
    }
}
