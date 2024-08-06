using Book_Evaluation_Management_System.Core.DTOs;

namespace Book_Evaluation_Management_System.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(int id, UserDTO userDTO);
        Task <IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
    }
}