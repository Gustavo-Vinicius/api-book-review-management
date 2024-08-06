using Book_Evaluation_Management_System.Core.Models.InputModels;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.UploadCoverImageBook
{
    public class UploadCoverImageBookCommand : IRequest<Unit>
    {
        public UploadCoverImageBookCommand(int id, UploadBookCoverInputModel uploadBookCoverInputModel)
        {
            Id = id;
            this.uploadBookCoverInputModel = uploadBookCoverInputModel;
        }

        public int Id { get; set; }
        public UploadBookCoverInputModel uploadBookCoverInputModel { get; set; }
    }
}