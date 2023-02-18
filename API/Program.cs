using Application.AccountRepository;
using Application.Commands.Accounts;
using Application.Commands.Accounts.Interfaces;
using Application.Commands.Transactions;
using Application.Commands.Transactions.Interfaces;
using Application.Context;
using Application.Repositories.ActivityRepository;
using Application.Repositories.TransactionRepository;
using Application.UserRepository;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Dependency Injection - DataContext
builder.Services.AddScoped<IDataContext, DataContext>();

// Dependency Injection - Repository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

// Dependency Injection - Account Commands
builder.Services.AddScoped<IGetAccountsCommand, GetAccountsCommand>();
builder.Services.AddScoped<IGetAccountCommand, GetAccountCommand>();
builder.Services.AddScoped<ICreateAccountCommand, CreateAccountCommand>();
builder.Services.AddScoped<IUpdateAccountCommand, UpdateAccountCommand>();
builder.Services.AddScoped<IDeleteAccountCommand, DeleteAccountCommand>();

// Dependency Injection - Transaction Commands
builder.Services.AddScoped<IGetTransactionCommand, GetTransactionCommand>();
builder.Services.AddScoped<IGetTransactionsCommand, GetTransactionsCommand>();
builder.Services.AddScoped<ICreateTransactionCommand, CreateTransactionCommand>();
builder.Services.AddScoped<IUpdateTransactionCommand, UpdateTransactionCommand>();
builder.Services.AddScoped<IDeleteTransactionCommand, DeleteTransactionCommand>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
