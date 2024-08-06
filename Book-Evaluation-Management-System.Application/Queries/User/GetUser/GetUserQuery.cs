using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.User.GetUser
{
    public class GetUserQuery : IRequest<IEnumerable<UserDTO>>
    {
        
    }
}