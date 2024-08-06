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

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _unityOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("No user in the database.");
            }

            var userDTO = new UserDTO
            {
                Name = user.Name,
                Email = user.Email
            };

            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> books = await _unityOfWork.Users.GetAllAsync();

            IEnumerable<UserDTO> userDTOs = books.Select(user => new UserDTO
            {
                Name = user.Name,
                Email = user.Email
            });

            return userDTOs;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDTO)
        {
            var userExisting = await _unityOfWork.Users.GetByIdAsync(id);
            if (userExisting == null)
            {
                throw new Exception("User not found !");
            }

            userExisting.Name = userDTO.Name;
            userExisting.Email = userDTO.Email;
            
            _unityOfWork.Users.Update(userExisting);

            await _unityOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
             var user = await _unityOfWork.Users.GetByIdAsync(id);
            _unityOfWork.Users.Delete(user);
            await _unityOfWork.CompleteAsync();
        }
    }
}