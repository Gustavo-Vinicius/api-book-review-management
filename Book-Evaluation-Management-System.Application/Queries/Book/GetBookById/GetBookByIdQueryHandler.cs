using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.Book.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookByIdAsync(request.Id);
            
        }
    }
}