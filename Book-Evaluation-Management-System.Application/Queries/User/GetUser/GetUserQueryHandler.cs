using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;      
        }
        public async Task<IEnumerable<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            
            return users;
        }
    }
}