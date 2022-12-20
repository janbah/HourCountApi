using System.Data;
using CrossCutting.DataObjects;
using DataStoring.DapperRepositories;
using DataStoring.MockRepositories;
using DataStoring.RepositoryContracts;
using HourCountApi.ViewModels;
using Microsoft.Data.SqlClient;
using WorkingTimeManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<WorkingTime>,WorkingTimeRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerMockRepository>();
builder.Services.AddTransient<IRepository<Fair>, FairMockRepository>();
builder.Services.AddTransient<IRepository<Project>,ProjectMockRepository>();
builder.Services.AddTransient<IRepository<Category>,CategoryMockRepository>();
builder.Services.AddTransient<IWorkingTimeManager,WorkingTimeManager>();
builder.Services.AddTransient<WorkingTimeAdapter>();

string connectionString = builder.Configuration.GetConnectionString("dbConnection");
builder.Services.AddTransient<IDbConnection>((_) => 
    new SqlConnection(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();