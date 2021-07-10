using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public interface ISchoolRepo
    {
        int Add<T>(T entity) where T : class;

        Task<bool> SaveAllSync();


        //School

        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<School> GetSchool(int id);


        //Teacher
        Task<IEnumerable<Teacher>> GetAllTeachersAsync
            ();

        Teacher GetTeacherAsync(int id);


        //Subject
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Subject GetSubject(int id);
        Task<IEnumerable<Teacher>> GetTeachersWithSchoolAsync(int id);
        Task<bool> DeleteTeacher(int id);
         Task<bool> Update(School school);
   
        
        

    }
}
