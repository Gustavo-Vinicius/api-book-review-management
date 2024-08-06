using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetAllReview
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, List<Assessment>>
    {
        private readonly IReviewsRepository _reviewsRepository;
        public GetAllReviewQueryHandler(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        public async Task<List<Assessment>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            return await _reviewsRepository.GetAllReviewAsync();
        }
    }
}