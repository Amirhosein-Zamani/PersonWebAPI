using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Application.DependencyInjection;
using PersonWebAPI.Application.Mapping;
using PersonWebAPI.Infra.Data.Context;
using PersonWebAPI.Infra.Data.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using PersonWebAPI.Application.Validator;



var builder = WebApplication.CreateBuilder(args);


MapsterConfig.Configure();

string connectionString = builder.Configuration.GetConnectionString("PersonWebAPIConnectionString");

builder.Services.AddDbContext<PersonWebAPIContext>(
    options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfraDataService();


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
