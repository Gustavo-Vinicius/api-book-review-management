using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.User.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}