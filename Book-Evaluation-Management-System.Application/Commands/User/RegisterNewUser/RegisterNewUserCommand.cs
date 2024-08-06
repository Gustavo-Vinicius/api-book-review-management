using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.User.RegisterNewUser
{
    public class RegisterNewUserCommand : IRequest<Unit>
    {
        public UserDTO User { get; set; }
    }
}