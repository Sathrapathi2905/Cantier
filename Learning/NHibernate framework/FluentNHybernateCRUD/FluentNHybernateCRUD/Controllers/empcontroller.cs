using FluentNHibernate.Conventions;
using FluentNHybernateCRUD.Models;
using FluentNHybernateCRUD.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentNHybernateCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empcontroller : ControllerBase
    {
        private readonly emprepository repository;

        public empcontroller()
        {
            repository = new emprepository();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<employee>> getall()
        {
            if (repository.getall().IsEmpty()) 
            {
                NoContent();
            }
            return Ok(repository.getall());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<employee>> getstudentbyid(int id) 
        {
            var emp=repository.getbyid(id);
            if (emp == null)
            {
                NoContent();
            }if(emp== null)
            {
                NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<IEnumerable<employee>> createemp([FromBody]employee emp)
        {
            if(emp == null)
            {
                return BadRequest();
            }
            repository.add(emp);
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public IActionResult updateemp(int id, [FromBody] employee emp)
        {
            var old = repository.getbyid(id);
            if(old == null) return NotFound();
            old.name = emp.name;
            old.dept = emp.dept;
            old.salary = emp.salary;
            repository.Update(old);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult deleteemp(int id) 
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
