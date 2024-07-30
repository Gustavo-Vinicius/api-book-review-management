using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}