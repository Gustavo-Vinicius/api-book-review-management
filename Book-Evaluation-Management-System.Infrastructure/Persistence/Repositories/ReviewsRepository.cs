using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book_Evaluation_Management_System.Infrastructure.Persistence.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly AppDbContext _context;
        public ReviewsRepository(IUnityOfWork unityOfWork, AppDbContext context)
        {
            _unityOfWork = unityOfWork;
            _context = context;
        }

        public async Task<int> AddReviewBookAsync(Assessment assessment)
        {

            await _unityOfWork.Assessments.AddAsync(assessment);
            await _unityOfWork.CompleteAsync();

            return assessment.Id;
        }

        public async Task<List<Assessment>> GetByLivroIdAsync(int idBook)
        {
            return await _context.Assessments.Where(a => a.IdLivro == idBook).ToListAsync();
        }

        public async Task<List<Assessment>> GetByUsuarioIdAsync(int userId)
        {
            return await _context.Assessments.Where(a => a.IdUsuario == userId).ToListAsync();
        }

        public Task<List<Assessment>> GetAllReviewAsync()
        {
            return _context.Assessments.ToListAsync();
        }

        public async Task<List<Assessment>> GetBooksReadInYearAsync(int year)
        {
            return await _context.Assessments
            .Where(a => a.CreationDate.Year == year)
            .ToListAsync();
        }
    }
}