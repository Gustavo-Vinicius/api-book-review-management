using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;

namespace Book_Evaluation_Management_System.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnityOfWork _unityOfWork;
        public UserRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task AddUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email
            };

            await _unityOfWork.Users.AddAsync(user);
            await _unityOfWork.CompleteAsync();
        }
    }
}