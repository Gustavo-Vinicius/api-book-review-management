using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.UploadCoverImageBook
{
    public class UploadCoverImageBookCommandHandler : IRequestHandler<UploadCoverImageBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public UploadCoverImageBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UploadCoverImageBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.UploadCoverImageBookAsync(request.Id, request.uploadBookCoverInputModel);

            return Unit.Value;
        }
    }
}