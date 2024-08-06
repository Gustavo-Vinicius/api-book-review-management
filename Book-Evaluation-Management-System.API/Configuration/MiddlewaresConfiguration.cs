namespace Book_Evaluation_Management_System.API.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static IServiceCollection AddMiddlewaresConfiguration(
                this IServiceCollection services
            )
        {
            // Remova esta linha, não é necessário registrar o middleware como serviço.
            // services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
