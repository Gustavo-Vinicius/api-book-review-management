using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByBook
{
    public class GetReviewsByBookQuery : IRequest<List<ReviewDTO>>
    {
        public GetReviewsByBookQuery(int idBook)
        {
            IdBook = idBook;
        }

        public int IdBook { get; set; }
    }
}