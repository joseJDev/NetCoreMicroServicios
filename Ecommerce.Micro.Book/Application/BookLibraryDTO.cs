using System;

namespace Ecommerce.Micro.Book.Application
{
    public class BookLibraryDTO
    {
        public Guid BookLibraryId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
