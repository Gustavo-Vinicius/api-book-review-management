using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Book_Evaluation_Management_System.Infrastructure.Persistence.Repositories;

namespace Book_Evaluation_Management_System.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
        }
    }
}