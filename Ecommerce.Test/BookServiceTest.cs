using AutoMapper;
using Ecommerce.Micro.Book.Application;
using Ecommerce.Micro.Book.Persistence;
using Moq;
using GenFu;
using Xunit;
using System.Collections.Generic;
using Ecommerce.Micro.Book.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Test
{
    public class BookServiceTest
    {
        private IEnumerable<BookLibrary> GetDataTest()
        {
            A.Configure<BookLibrary>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.BookLibraryId, () => { return Guid.NewGuid(); });

            var list = A.ListOf<BookLibrary>(30);
            list[0].BookLibraryId = Guid.Empty;

            return list;
        }

        private Mock<ContextBook> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<BookLibrary>>();

            // Indicamos que debe ser tipo entidad, son propiedades que debe tener toda
            // propiedad de entity
            dbSet.As<IQueryable<BookLibrary>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<BookLibrary>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<BookLibrary>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<BookLibrary>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BookLibrary>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<BookLibrary>(dataTest.GetEnumerator()));

            var context = new Mock<ContextBook>();
            context.Setup(x => x.BookLibrary).Returns(dbSet.Object);
            
            return context;

        }

        [Fact]
        public async void GetBooks()
        {
            System.Diagnostics.Debugger.Launch();

            // Emular Context
            var mockContext = CreateContext();

            //Emular Mapping
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mockMapper = mapConfig.CreateMapper();

            // Instanciar a Handler y pasar parametros
            BookList.Handler handler = new BookList.Handler(mockContext.Object, mockMapper); 

            BookList.Execute request = new BookList.Execute();
            
            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());
        }
    }
}
