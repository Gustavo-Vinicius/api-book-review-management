using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Entities;

namespace Book_Evaluation_Management_System.Core.Interfaces.Repositories
{
    public interface IReviewsRepository
    {
        Task<int> AddReviewBookAsync(Assessment assessment);
        Task<List<Assessment>> GetByLivroIdAsync(int bookId);
        Task<List<Assessment>> GetByUsuarioIdAsync(int userId);
        Task<List<Assessment>> GetAllReviewAsync();
        Task<List<Assessment>> GetBooksReadInYearAsync(int year);
    }
}