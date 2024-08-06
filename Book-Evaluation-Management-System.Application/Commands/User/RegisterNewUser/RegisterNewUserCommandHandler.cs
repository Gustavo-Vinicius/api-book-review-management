using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.User.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public RegisterNewUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;      
        }

        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddUserAsync(request.User);
            return Unit.Value;
        }
    }
}