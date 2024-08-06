using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Commands.User.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;      
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUserAsync(request.Id, request.User);

            return Unit.Value;
        }
    }
}