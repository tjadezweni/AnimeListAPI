using AnimeListAPI.Models;
using AnimeListAPI.Repositories;
using AnimeListAPI.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("AnimeList");
});

builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<IStudiosRepository, StudiosRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

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

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();
