using AutoMapper;
using Scaffolder.DTOs;

namespace Scaffolder.Profiles{
    class ScaffoldProfile : Profile
    {
        public ScaffoldProfile(){
            CreateMap<Scaffold, ScaffoldReadDTO>();
        }
    }
}