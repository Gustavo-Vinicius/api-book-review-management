using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetBooksReadInYear
{
    public class GetBooksReadInYearQueryHandler : IRequestHandler<GetBooksReadInYearQuery, int>
    {
        private readonly IReviewsRepository _reviewsRepository;
        public GetBooksReadInYearQueryHandler(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        public async Task<int> Handle(GetBooksReadInYearQuery request, CancellationToken cancellationToken)
        {
            var assessments = await _reviewsRepository.GetBooksReadInYearAsync(request.Year);

            return assessments.Count;
        }
    }
}