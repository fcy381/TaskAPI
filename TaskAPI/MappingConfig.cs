using AutoMapper;
using JobAPI.Models;
using JobAPI.Entities;

namespace JobAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Job, JobGetDTO>().ReverseMap();
            CreateMap<Job, JobCreateDTO>().ReverseMap();
            CreateMap<Job, JobUpdateDTO>().ReverseMap();
        }
    }
}
