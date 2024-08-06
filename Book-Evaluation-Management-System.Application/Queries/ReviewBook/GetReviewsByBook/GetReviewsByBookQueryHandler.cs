using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByBook
{
    public class GetReviewsByBookQueryHandler : IRequestHandler<GetReviewsByBookQuery, List<ReviewDTO>>
    {
        private readonly IReviewsRepository _reviewsRepository;
        public GetReviewsByBookQueryHandler(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        public async Task<List<ReviewDTO>> Handle(GetReviewsByBookQuery request, CancellationToken cancellationToken)
        {
            var assessments = await _reviewsRepository.GetByLivroIdAsync(request.IdBook);

            return assessments.Select(a => new ReviewDTO
            {
                Id = a.Id,
                Note = a.Note,
                Description = a.Description,
                IdLivro = a.IdLivro,
                IdUsuario = a.IdUsuario
            }).ToList();
        }
    }
}