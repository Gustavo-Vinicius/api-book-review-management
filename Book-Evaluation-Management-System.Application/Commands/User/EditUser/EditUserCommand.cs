using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.User.EditUser
{
    public class EditUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
    }
}