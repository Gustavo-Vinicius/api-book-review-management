using Book_Evaluation_Management_System.Core.Entities;

namespace Book_Evaluation_Management_System.Core.Interfaces.Repositories
{
    public interface IUnityOfWork : IDisposable
    {
        IBaseRepository<Assessment> Assessments { get; }
        IBaseRepository<Book> Books { get; }
        IBaseRepository<User> Users { get; }
        Task<int> CompleteAsync();
    }
}