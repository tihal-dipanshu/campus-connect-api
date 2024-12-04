using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using CampusConnect.Business.IService; 
using CampusConnect.Business.Service;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using CampusConnect.Business.IUnitOfWork;
using CampusConnect.DataAccess.Repositories;
using CampusConnect.Business.UnitOfWork;
using CampusConnect.API.Hubs;
using CampusConnect.Business.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CampusConnectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEventsService, EventsService>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IChatsService, ChatsService>();
builder.Services.AddScoped<IChatsRepository, ChatsRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEventAttendeeService, EventAttendeeService>();
builder.Services.AddScoped<IEventAttendeeRepository, EventAttendeeRepository>();
builder.Services.AddScoped<IEventCategoryService, EventCategoryService>();
builder.Services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
builder.Services.AddScoped<IVolunteerService, VolunteerService>();
builder.Services.AddScoped<IVolunteerRepository, VolunteerRepository>();



builder.Services.AddSignalR();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();