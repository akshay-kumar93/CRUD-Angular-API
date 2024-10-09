using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CodeFirstContext context;
        private readonly SieveProcessor sieveProcessor;

        public StudentsController(CodeFirstContext context, SieveProcessor sieveProcessor)
        {
            this.context = context;
            this.sieveProcessor = sieveProcessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> getAllStudent()
        {
            var std = await context.Students.ToListAsync();
            return Ok(std);
        }

        //filter,sorting , pagination


        //[HttpGet]
        //public async Task<List<Student>> getStudents([FromQuery] SieveModel sieve)
        //{
        //    var result = context.Students.AsQueryable();
        //    result = sieveProcessor.Apply(sieve, result);
        //    return await result.ToListAsync();
        //} 



        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getOneStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return std;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> postStudentData(Student std)
        {
            var newStd = await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(newStd.Entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> updateStudent(int id,Student std) 
        {
            if(id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            context.SaveChanges();
            return Ok();
        }
    }
}
