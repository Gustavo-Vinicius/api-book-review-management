using Book_Evaluation_Management_System.Application.DomainEvents.ReviewBooks;
using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.ReviewBook.AddReviewBook
{
    public class AddReviewBookCommandHandler : IRequestHandler<AddReviewBookCommand, int>
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IMediator _mediator;
        public AddReviewBookCommandHandler(IReviewsRepository reviewsRepository, IMediator mediator)
        {
            _reviewsRepository = reviewsRepository;
            _mediator = mediator;
        }
        public async Task<int> Handle(AddReviewBookCommand request, CancellationToken cancellationToken)
        {
            var reviewBook = new Assessment
            {
                Note = request.AddNewReviewBookInputModel.Note,
                Description = request.AddNewReviewBookInputModel.Description,
                IdLivro = request.AddNewReviewBookInputModel.IdLivro,
                IdUsuario = request.AddNewReviewBookInputModel.IdUsuario,
                CreationDate = DateTime.Now
            };

            var idReviewBook = await _reviewsRepository.AddReviewBookAsync(reviewBook);

            await _mediator.Publish(new AddReviewBookEvent(reviewBook.Id, reviewBook.IdLivro, reviewBook.IdUsuario, reviewBook.CreationDate));

            return idReviewBook;
        }
    }
}