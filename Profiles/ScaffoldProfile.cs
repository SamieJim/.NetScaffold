using AutoMapper;
using Scaffolder.DTOs;
using Scaffolder.Models;

namespace Scaffolder.Profiles{
    class ScaffoldProfile : Profile
    {
        public ScaffoldProfile(){
            CreateMap<Scaffold, ScaffoldReadDTO>();
            CreateMap<ScaffoldCreateDTO, Scaffold>();
        }
    }
}