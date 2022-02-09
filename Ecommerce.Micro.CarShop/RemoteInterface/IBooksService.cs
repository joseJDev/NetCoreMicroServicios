using Ecommerce.Micro.CarShop.RemoteModel;
using System;
using System.Threading.Tasks;


namespace Ecommerce.Micro.CarShop.RemoteInterface
{
    public interface IBooksService
    {
        Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(Guid BookId);
    }
}
