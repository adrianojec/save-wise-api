using Application.Commands.Accounts;
using Application.Commands.Accounts.Interfaces;
using Application.Commands.Activities;
using Application.Commands.Transactions;
using Application.Commands.Transactions.Interfaces;

namespace API.Extensions
{
    public static class CommandsServiceExtensions
    {
        public static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            // Account Commands
            services.AddScoped<IGetAccountsCommand, GetAccountsCommand>();
            services.AddScoped<IGetAccountCommand, GetAccountCommand>();
            services.AddScoped<ICreateAccountCommand, CreateAccountCommand>();
            services.AddScoped<IUpdateAccountCommand, UpdateAccountCommand>();
            services.AddScoped<IDeleteAccountCommand, DeleteAccountCommand>();

            // Transaction Commands
            services.AddScoped<IGetTransactionCommand, GetTransactionCommand>();
            services.AddScoped<IGetTransactionsCommand, GetTransactionsCommand>();
            services.AddScoped<ICreateTransactionCommand, CreateTransactionCommand>();
            services.AddScoped<IUpdateTransactionCommand, UpdateTransactionCommand>();
            services.AddScoped<IDeleteTransactionCommand, DeleteTransactionCommand>();

            // Activity Commands
            services.AddScoped<IGetActivitiesCommand, GetActivitiesCommand>();

            return services;
        }
    }
}