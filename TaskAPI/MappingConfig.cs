using AutoMapper;
using JobAPI.Models;
using TaskAPI.Entities;

namespace JobAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Job, JobCreateDTO>().ReverseMap();       
        }
    }
}
