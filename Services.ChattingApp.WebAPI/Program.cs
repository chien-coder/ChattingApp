using Microsoft.EntityFrameworkCore;
using Services.ChattingApp.DataAccess;
using Services.ChattingApp.DataAccess.Repositories;
using Services.ChattingApp.DataAccess.Repositories.Base;
using Services.ChattingApp.DataAccess.UnitOfWork;
using Services.ChattingApp.Domain.Interfaces;
using Services.ChattingApp.Domain.Interfaces.Base;
using Services.ChattingApp.WebAPI.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SignalR
builder.Services.AddSignalR();

// Repository
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Connect to Postgres with connection string from app settings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString != null)
{
    builder.Services.AddDbContext<ApplicationContext>(options =>
     options.UseNpgsql(connectionString, sql => sql.MigrationsAssembly("Services.ChattingApp.WebAPI")));
}
var app = builder.Build();

// CreateDbIfNotExists
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<ApplicationContext>();
//        context.Database.EnsureCreated();
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred creating the DB.");
//    }
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/chatHub");

app.Run();
