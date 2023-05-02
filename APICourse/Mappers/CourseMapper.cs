using APICourse.DTO;
using APICourse.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.Mappers
{
    public class CourseMapper
    {
        private MapperConfiguration _mapConfig;

        public CourseMapper()
        {
            IniciaConfiguracao();
        }

        public MapperConfiguration RetornaMapperConfiguration()
        {
            return _mapConfig;
        }

        private void IniciaConfiguracao()
        {
            if(_mapConfig == null)
            {                
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Course, CourseDTO>()
                    .ForCtorParam("_id", opt => opt.MapFrom(ent => ent.Id))
                    .ReverseMap();
                });
                _mapConfig = config;
            }
        }
    }
}
