using Microsoft.EntityFrameworkCore;
using RESTAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseInMemoryDatabase("todo"));

/* var configuration = builder.Configuration;

builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
}); */

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

app.UseAuthorization();

app.MapControllers();

app.Run();
