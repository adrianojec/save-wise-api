using Application.AccountRepository;
using Application.Commands.Accounts;
using Application.Commands.Accounts.Interfaces;
using Application.Context;
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

// Dependency Injection - Commands
builder.Services.AddScoped<ICreateAccountCommand, CreateAccountCommand>();
builder.Services.AddScoped<IGetAccountsCommand, GetAccountsCommand>();
builder.Services.AddScoped<IGetAccountCommand, GetAccountCommand>();
builder.Services.AddScoped<IUpdateAccountCommand, UpdateAccountCommand>();
builder.Services.AddScoped<IDeleteAccountCommand, DeleteAccountCommand>();

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
