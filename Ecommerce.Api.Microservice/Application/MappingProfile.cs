using AutoMapper;
using Ecommerce.Api.Microservice.Models;

namespace Ecommerce.Api.Microservice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>();
        }
    }
}
