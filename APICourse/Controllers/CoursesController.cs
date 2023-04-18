using APICourse.Models;
using APICourse.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseContext _context;

        public CoursesController(CourseContext context)
        {
            _context = context;
        }


        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
            //List<Course> listaCourses = new List<Course>();
            //var listaCoursess = _context.Courses;            

            return Ok(_context.Courses);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
                return Ok(course);
            else
            {
                string msg = $"Curso solicitado não encontrado!! Id: {id}";
                return NotFound(msg);
            }
            //return NotFound("{\"Status\":404, \"Erro\":\"Entidade não encontrada!!\"}");

            //return "value";
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Post([FromBody] Course value)
        {            
            _context.Add(value);
            int numLinhas = _context.SaveChanges();
            if (numLinhas > 0)
                return Ok(value);
            else
                return BadRequest("Não foi possível adicionar o Curso!");
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course value)
        {
            var curso = _context.Courses.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (curso == null) return NotFound("Curso não encontrado para atualizar");
            value.Id = curso.Id;
            _context.Update(value);
            _context.SaveChanges();

            return Ok(value);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string msg = $"Curso com id {id} não encontrado para apagar";
            var curso = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (curso == null) return NotFound(msg);

            _context.Remove(curso);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
