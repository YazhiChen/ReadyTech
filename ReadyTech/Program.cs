using Microsoft.EntityFrameworkCore;
using ReadyTech.Extensions;
using ReadyTech.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureWrapper();
builder.Services.AddControllers();
builder.Services.AddDbContext<ReadyTechDbContext>(opt =>
    opt.UseInMemoryDatabase("ReadyTech"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
