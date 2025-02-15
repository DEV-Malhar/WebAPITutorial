using _02ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02ASPCoreWebAPICRUD.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MytestDatabaseContext context;

        public StudentAPIController(MytestDatabaseContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);        // In Web Api we usually dont return View hence some response is return 
        }
        [HttpGet("{stid}")]
        public async Task<ActionResult<Student>> GetStudentById(int stid)
        {
            var student = await context.Students.FindAsync(stid);
            if (student == null) 
            {
                return NotFound();
            }
            else 
            {
                return student;
            }

        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id ,Student std)
        {
            if(id !=std.StdId)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
