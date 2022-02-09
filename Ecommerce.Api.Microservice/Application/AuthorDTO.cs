using System;

namespace Ecommerce.Api.Microservice.Application
{
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string AuthorGuid { get; set; }
    }
}
