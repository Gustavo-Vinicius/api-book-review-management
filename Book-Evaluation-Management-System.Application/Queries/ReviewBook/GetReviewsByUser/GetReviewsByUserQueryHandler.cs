using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByUser
{
    public class GetReviewsByUserQueryHandler : IRequestHandler<GetReviewsByUserQuery, List<ReviewDTO>>
    {
        private readonly IReviewsRepository _reviewsRepository;
        public GetReviewsByUserQueryHandler(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;      
        }
        public async Task<List<ReviewDTO>> Handle(GetReviewsByUserQuery request, CancellationToken cancellationToken)
        {
            var assessments = await _reviewsRepository.GetByUsuarioIdAsync(request.IdUser);

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