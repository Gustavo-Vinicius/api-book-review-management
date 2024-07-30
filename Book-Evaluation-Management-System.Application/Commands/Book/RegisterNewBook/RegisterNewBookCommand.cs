using Book_Evaluation_Management_System.Core.Enums;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.RegisterNewBook
{
    public class RegisterNewBookCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string PublishingCompany { get; set; }
        public string Gender { get; set; }
        public int YearOfPublication { get; set; }
        public int QuantityPages { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal AverageGrade { get; set; }
        public string BookCover { get; set; }
    }
}