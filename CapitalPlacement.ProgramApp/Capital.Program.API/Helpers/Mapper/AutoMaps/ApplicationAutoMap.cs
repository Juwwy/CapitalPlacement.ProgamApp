using AutoMapper;
using Capital.Program.Domain.Entities;

namespace Capital.Program.API.Helpers.Mapper.AutoMaps
{
    public class ApplicationAutoMap : Profile
    {
        public ApplicationAutoMap()
        {
            CreateMap<EmployerProgram, EmployerProgram>();
        }
    }
}
