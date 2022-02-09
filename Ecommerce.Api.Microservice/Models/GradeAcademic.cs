using System;

namespace Ecommerce.Api.Microservice.Models
{
    public class GradeAcademic
    {
        public int GradeAcademicId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string GradeAcademicGuide { get; set; }
    }
}
