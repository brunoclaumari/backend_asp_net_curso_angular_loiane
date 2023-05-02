using APICourse.Constants;
using APICourse.DTO;
using APICourse.Exceptions;
using APICourse.Models;
using APICourse.Repository;
using APICourse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {        
        private readonly CourseService _service;

        public CoursesController(CourseService courseService)
        {            
            _service = courseService;
        }


        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult<List<CourseDTO>> GetAll()
        {            
            return Ok(_service.GetAll().Result);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById([Required] int id)
        {
            CourseDTO courseDTO = _service.GetById(id).Result;           
            if (courseDTO != null)
                return Ok(courseDTO);
            else
            {
                string msg = $"Curso solicitado não encontrado!! Id: {id}";
                throw new MyEntityNotFoundException(msg);
            }
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Create([FromBody] CourseDTO value)
        {            
            string msg = "Não foi possível adicionar o Curso!";
            var courseDTO = _service.Create(value).Result;
            if (courseDTO != null)
                return CreatedAtAction(nameof(Create), courseDTO);
            else
                throw new CreateFailException(msg);
        }

        // PUT api/<CoursesController>/5
        //public IActionResult Update(int id, [FromBody] Course value)
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CourseDTO value)
        {
            var cursoAtualizado = _service.Update(id, value);
            
            if (cursoAtualizado.Result != null)
                return Ok(cursoAtualizado.Result);
            else
                throw new MyEntityNotFoundException($"Curso com id = {id} não foi encontrado para atualizar");
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string msg = $"Curso com id {id} não encontrado para apagar";

            int numLinhas = _service.Delete(id).Result;
            if (numLinhas > 0)
                return NoContent();
            else
                throw new MyEntityNotFoundException(msg);            
        }
    }
}
