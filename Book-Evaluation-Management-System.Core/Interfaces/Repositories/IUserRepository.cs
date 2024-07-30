using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Entities;

namespace Book_Evaluation_Management_System.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserDTO userDTO);
    }
}