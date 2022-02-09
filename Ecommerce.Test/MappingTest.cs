using AutoMapper;
using Ecommerce.Micro.Book.Application;
using Ecommerce.Micro.Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<BookLibrary, BookLibraryDTO>();
        }
    }
}
