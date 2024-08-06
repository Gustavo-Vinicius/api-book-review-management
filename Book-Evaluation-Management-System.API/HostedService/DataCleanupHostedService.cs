using Book_Evaluation_Management_System.Infrastructure.Persistence;

namespace Book_Evaluation_Management_System.API.HostedService
{
    public class DataCleanupHostedService : IHostedService, IDisposable
    {

        private readonly ILogger<DataCleanupHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public DataCleanupHostedService(ILogger<DataCleanupHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Data Cleanup Hosted Service is starting.");
            _timer = new Timer(CleanUpData, null, TimeSpan.Zero, TimeSpan.FromHours(24)); // Executa a cada 24 horas
            return Task.CompletedTask;
        }

        private void CleanUpData(object state)
        {
            _logger.LogInformation("Data Cleanup Hosted Service is working.");

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var oneYearAgo = DateTime.Now.AddYears(-1);
                var oldAssessments = dbContext.Assessments.Where(a => a.CreationDate < oneYearAgo).ToList();

                if (oldAssessments.Any())
                {
                    dbContext.Assessments.RemoveRange(oldAssessments);
                    dbContext.SaveChanges();

                    _logger.LogInformation($"Deleted {oldAssessments.Count} old assessments.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Data Cleanup Hosted Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}