using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentcontroller : ControllerBase
    {
        private readonly studentdbcontext _studentdbcontext;
        public studentcontroller(studentdbcontext studentdbcontext)
        {
            _studentdbcontext = studentdbcontext;
        }


        [HttpGet]
        [Route("getstudent")]
        public async Task<IEnumerable<student>> GetStudents()
        {
            return await _studentdbcontext.students.ToListAsync();        
        }


        [HttpPost]
        [Route("addstudent")]
        public async Task<student>Addstudent(student objstudent)
        {

            _studentdbcontext.students.Add(objstudent);
            await _studentdbcontext.SaveChangesAsync();
            return objstudent;
        }


        [HttpPatch]
        [Route("updatestudent/{id}")]
        public async Task<student>Updatestudent(student objstudent)
        {
            _studentdbcontext.Entry(objstudent).State = EntityState.Modified;
            await _studentdbcontext.SaveChangesAsync();
            return objstudent;
        }


        [HttpDelete]
        [Route("deletestudent/{id}")]
        public bool Deletestudent(int id) {
            bool a=false;
            var student=_studentdbcontext.students.Find(id);
            if (student != null)
            {
                a = true;
                _studentdbcontext.Entry(student).State = EntityState.Deleted;
                _studentdbcontext.SaveChanges();
            }
            else { a = false; }
            return a;
        }
    }
}
