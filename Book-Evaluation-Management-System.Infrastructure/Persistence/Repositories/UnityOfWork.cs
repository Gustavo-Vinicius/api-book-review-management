using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;

namespace Book_Evaluation_Management_System.Infrastructure.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _context;
        private IBaseRepository<Assessment> _assessments;
        private IBaseRepository<Book> _books;
        private IBaseRepository<User> _users; 

         public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IBaseRepository<Assessment> Assessments =>  _assessments ??= new BaseRepository<Assessment>(_context);
        public IBaseRepository<User> Users => _users ??= new BaseRepository<User>(_context);
        public IBaseRepository<Book> Books => _books ??= new BaseRepository<Book>(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}