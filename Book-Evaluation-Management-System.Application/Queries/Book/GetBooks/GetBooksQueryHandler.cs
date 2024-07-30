using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.Book.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
           return await _bookRepository.GetBooks();
        }
    }
}