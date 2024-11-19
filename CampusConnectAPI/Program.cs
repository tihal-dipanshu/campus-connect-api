using Microsoft.EntityFrameworkCore;
using CampusConnect.Business.IService; 
using CampusConnect.Business.Service;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using CampusConnect.Business.IUnitOfWork;
using CampusConnect.DataAccess.Repositories;
using CampusConnect.Business.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CampusConnectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

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

app.MapControllers();

app.Run();