using Application.Repositories.AccountRepositories;
using Application.Repositories.ActivityRepositories;
using Application.Repositories.TransactionRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Repositories
{
    public static class IOCExtension
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            // Dependency Injection - Repository
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<ITransactionRepository, TransactionRepository>();
            service.AddScoped<IActivityRepository, ActivityRepository>();
        }
    }
}