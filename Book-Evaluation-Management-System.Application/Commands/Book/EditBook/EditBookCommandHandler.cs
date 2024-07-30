using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.EditBook
{
    public class EditBookCommandHandler : IRequestHandler<EditBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public EditBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.EditBookAsync( request.Id, request.Book);

            return Unit.Value;
        }
    }
}