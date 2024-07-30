using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBookAsync(request.Id);

            return Unit.Value;
        }
    }
}