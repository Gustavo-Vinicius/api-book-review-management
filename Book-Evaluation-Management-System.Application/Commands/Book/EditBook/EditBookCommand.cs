using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.Book.EditBook
{
    public class EditBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public BookDTO Book { get; set; }
    }
}