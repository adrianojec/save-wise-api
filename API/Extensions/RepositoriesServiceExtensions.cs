using Application.Repositories.AccountRepositories;
using Application.Repositories.ActivityRepositories;
using Application.Repositories.TransactionRepositories;

namespace API.Extensions
{
    public static class RepositoriesServiceExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            // Dependency Injection - Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            return services;
        }
    }
}