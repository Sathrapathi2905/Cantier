using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudoperationusingentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentcontroller : ControllerBase
    {
        private readonly BlackmirrorContext context;
        public studentcontroller(BlackmirrorContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> getstudents()
        {
            var data = await context.Students.ToListAsync();  
            return Ok(data);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getstudentbyid(int id)
        {
            var student= await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }
        [HttpPost]
        public async Task<ActionResult<Student>> addstudent(Student stu)
        {
            context.Students.AddAsync(stu);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Student>> updatestudent(int id,Student stu)
        {
            if (stu.Id != id) {
                return BadRequest();
            }
            context.Entry(stu).State= EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(stu);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> deletestudent(int id) 
        {
            var del = await context.Students.FindAsync(id);
            if (del == null)
            {
                return NotFound();
            }
            context.Students.Remove(del);
            await context.SaveChangesAsync();
            return Ok();
            
        }

    }
}
