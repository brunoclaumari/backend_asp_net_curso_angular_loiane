using APICourse.Constants;
using APICourse.DTO;
using APICourse.Exceptions;
using APICourse.Mappers;
using APICourse.Models;
using APICourse.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.Services
{
    
    public class CourseService
    {
        private readonly CourseContext _courseContext;

        //private CourseMapper _courseMapper;
        private readonly IMapper _mapper;

        public CourseService(CourseContext courseContext)
        {
            _courseContext = courseContext;
            _mapper = new CourseMapper().RetornaMapperConfiguration().CreateMapper();
        }

        public async Task<List<CourseDTO>> GetAll()
        {            
            List<Course> listaCursos = await _courseContext.Courses.Where(x => x.Status == UtilConstants.Ativo).ToListAsync();

            List<CourseDTO> dtos = new List<CourseDTO>();
            listaCursos.ForEach(curso =>
            {
                dtos.Add(_mapper.Map<CourseDTO>(curso));                
            });

            return dtos;            
        }

        public async Task<CourseDTO> GetById(int id)
        {            
            CourseDTO courseDTO = _mapper
                .Map<CourseDTO>(await _courseContext.Courses.FirstOrDefaultAsync(x => x.Id == id && x.Status == UtilConstants.Ativo));
            
            if (courseDTO != null)
                return courseDTO;
            else                           
                return null;           
        }

        public async Task<CourseDTO> Create(CourseDTO value)
        {            
            var result = _courseContext.Add(_mapper.Map<Course>(value));
            int numLinhasAfetadas = await _courseContext.SaveChangesAsync();
            if (numLinhasAfetadas > 0)
                return _mapper.Map<CourseDTO>(result.Entity);
            else
                return null;            
        }

        //public async Task<int?> Update(int id, Course value)
        public async Task<CourseDTO> Update(int id, CourseDTO value)
        {
            CourseDTO dto = null;
            var cursoSearch = await _courseContext.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.Status == UtilConstants.Ativo);
            if (cursoSearch == null) 
                return null;
            else
            {
                var cursoMapped = _mapper.Map<Course>(value);
                cursoMapped.Id = cursoSearch.Id;
                _courseContext.Update(cursoMapped);
                int? numLinhasAfetadas = await _courseContext.SaveChangesAsync();                
                if (numLinhasAfetadas > 0)
                    dto = _mapper.Map<CourseDTO>(cursoMapped);
            }
            return dto;
        }

        public async Task<int> Delete(int id)
        {            
            var curso = await _courseContext.Courses.FirstOrDefaultAsync(x => x.Id == id && x.Status == UtilConstants.Ativo);
            if (curso == null) return -1;

            _courseContext.Remove(curso);
            int numLinhasAfetadas = await _courseContext.SaveChangesAsync();

            return numLinhasAfetadas;
        }

    }
}
