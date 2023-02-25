using DataAccess4.Context;
using DataAccess4.DataAccessRepo;
using Microsoft.EntityFrameworkCore;
using Service3.IRepository;
using Service3.Respository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(builder.
    Configuration.GetConnectionString("myconnection")
, dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IDepartment, DepartmentRepository>();
builder.Services.AddScoped<IStudentDb, StudentDb>();
builder.Services.AddScoped<IDepartmentDb, DepartmentDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
