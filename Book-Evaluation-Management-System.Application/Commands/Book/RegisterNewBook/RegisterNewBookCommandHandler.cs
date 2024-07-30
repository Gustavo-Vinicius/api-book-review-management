using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.RegisterNewBook
{
    public class RegisterNewBookCommandHandler : IRequestHandler<RegisterNewBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public RegisterNewBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(RegisterNewBookCommand request, CancellationToken cancellationToken)
        {
            byte[] imagemdata = System.IO.File.ReadAllBytes(request.BookCover);

            await _bookRepository.AddBookAsync(
                request.Title, 
                request.Description, 
                request.ISBN, 
                request.Author, 
                request.PublishingCompany, 
                request.Gender, 
                request.YearOfPublication, 
                request.QuantityPages, 
                request.CreationDate, 
                request.AverageGrade,
                imagemdata);
            
            return Unit.Value;
        }
    }
}