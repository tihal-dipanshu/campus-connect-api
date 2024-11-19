using Microsoft.EntityFrameworkCore;
using CampusConnect.DataAccess; // Adjust this namespace if needed
using CampusConnect.Business.IService; // Adjust this namespace if needed
using CampusConnect.Business.Service; // Adjust this namespace if needed
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using CampusConnect.Business.IUnitOfWork;
using CampusConnect.DataAccess.Repositories;
using CampusConnect.Business.UnitOfWork; // Adjust this namespace if needed

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext
builder.Services.AddDbContext<CampusConnectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Assuming you have a UnitOfWork implementation

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Remove this line if you don't need authorization for now
// app.UseAuthorization();

app.MapControllers();

app.Run();