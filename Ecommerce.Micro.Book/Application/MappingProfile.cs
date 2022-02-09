using AutoMapper;
using Ecommerce.Micro.Book.Models;

namespace Ecommerce.Micro.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookLibrary, BookLibraryDTO>();
        }
    }
}
