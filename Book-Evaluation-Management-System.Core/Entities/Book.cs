using Book_Evaluation_Management_System.Core.Enums;

namespace Book_Evaluation_Management_System.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string PublishingCompany { get; set; }
        public GeneroLivroEnum Gender { get; set; }
        public int YearOfPublication { get; set; }
        public int QuantityPages { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal AverageGrade { get; set; }
        public byte[] BookCover { get; set; }
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}