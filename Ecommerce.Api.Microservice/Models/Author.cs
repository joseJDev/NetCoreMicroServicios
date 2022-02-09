using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecommerce.Api.Microservice.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public ICollection<GradeAcademic> ListGradeAcademic { get; set; }
        public string AuthorGuid { get; set; }
    }
}
