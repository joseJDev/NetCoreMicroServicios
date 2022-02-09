using Ecommerce.Micro.CarShop.RemoteInterface;
using Ecommerce.Micro.CarShop.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Micro.CarShop.RemoteServices
{
    public class BookServices : IBooksService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookServices> _logger;

        public BookServices(IHttpClientFactory httpClient, ILogger<BookServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/book/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<BookRemote>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
