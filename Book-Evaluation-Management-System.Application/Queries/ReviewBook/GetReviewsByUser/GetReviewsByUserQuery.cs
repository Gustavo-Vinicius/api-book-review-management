using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByUser
{
    public class GetReviewsByUserQuery : IRequest<List<ReviewDTO>>
    {
        public GetReviewsByUserQuery(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; set; }
    }
}