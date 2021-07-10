using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class SchoolRepo : ISchoolRepo
    {
        //This is the DBContext Entry for all the Entities
        private readonly ApplicationDbContext _db;

        public SchoolRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public int Add<T>(T entity) where T : class
        {
            _db.Add(entity);
            return 0;
        }

        public async Task<bool> DeleteTeacher(int id)
        {
            try
            {
                var teacher =  _db.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
                if (teacher != null)
                {

                   _db.Teachers.Remove(teacher);

                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        public async Task<IEnumerable<School>> GetAllSchoolsAsync()
        {
            
            return  _db.Schools.ToList();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return  (_db.Subjects.ToList());
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return  _db.Teachers.ToList();
        }

        public Task<School> GetSchool(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<School> GetSchoolAsync(int id)
        {
            School school= _db.Schools

                .Where(c => c.SchoolId == id)
                .FirstOrDefault();
            return  school;
        }

        public Subject GetSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<IEnumerable<Teacher>> GetTeachersWithSchoolAsync(int id)
        {


            var list = _db.Teachers
            .Include(t => t.subject)
            .Where(t => t.SchoolId == id)
             .OrderBy(t => t.TeacherId);

            return list;

        }

        public async Task<bool> SaveAllSync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(School school)

        {
            School s;
             s = (from p in _db.Schools where p.SchoolId == school.SchoolId select p).SingleOrDefault();
            s.Address = school.Address;
       
     
            return true;

            
        }

        
    }
}
