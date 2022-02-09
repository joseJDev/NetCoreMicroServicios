using System;

namespace Ecommerce.Micro.CarShop.RemoteModel
{
    public class BookRemote
    {
        public Guid BookLibraryId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
