using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Book_Evaluation_Management_System.Core.Models.InputModels;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.ReviewBook.AddReviewBook
{
    public class AddReviewBookCommand : IRequest<int>
    {
        public AddNewReviewBookInputModel AddNewReviewBookInputModel { get; set; }
    }
}