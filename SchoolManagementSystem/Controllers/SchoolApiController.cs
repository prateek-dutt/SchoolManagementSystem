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
    public class SchoolApiController : ControllerBase
    {

        private readonly ISchoolRepo schoolrepo;
        private readonly ILogger _logger;


        public SchoolApiController(ISchoolRepo a,ILogger<SchoolRepo>logger)
        {

            schoolrepo = a;
            _logger = logger;


        }
        // GET: api/<SchoolApiController>

        [HttpGet]
        public async Task<IEnumerable<School>> Get()
        {
            return await schoolrepo.GetAllSchoolsAsync();
        }

        // GET api/<SchoolApiController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SchoolApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] School school)
        {
            try
            {
                schoolrepo.Add(school);
                await schoolrepo.SaveAllSync();
                return Ok("Created Student with StudentID:" + school.SchoolId);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);


                //return await BadRequest("Server cant serve this request");
                return BadRequest("Error");
            }



        }

        // PUT api/<SchoolApiController>/5
        // [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] School school)
        {
            try
            {
                await schoolrepo.Update(school);
                await schoolrepo.SaveAllSync();
                return Ok("Record Has Been Edited");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return BadRequest("Server cant serve, this is a bad request");
            }


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var teachers = await schoolrepo.GetTeachersWithSchoolAsync(id);
                return Ok(teachers);
            }

            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Server cant serve this request");

            }
            

          
        }
        // DELETE api/<SchoolApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
