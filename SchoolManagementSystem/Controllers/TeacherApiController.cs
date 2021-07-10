using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly ISchoolRepo _db;
        private readonly ILogger _logger;

        public TeacherApiController(ISchoolRepo db,ILogger<SchoolRepo>logger)
        {
            _db = db;
            _logger = logger;
        }
        // GET: api/<TeacherApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            try
            {
               _db.Add(teacher);
                await _db.SaveAllSync();
                return Ok("Created Teacher With ID: " + teacher.TeacherId);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("BAD REQUEST");
            }


        }

        // PUT api/<TeacherApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _db.DeleteTeacher(id);
                await _db.SaveAllSync();
                return Ok("Record Has Been Deleted");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Sever cant serve this request");
            }
        }
    }
}
