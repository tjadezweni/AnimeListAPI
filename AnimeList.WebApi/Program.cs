using AnimeListAPI.Application.Queries.GetAllCountries;
using AnimeListAPI.Domain.Interfaces;
using AnimeListAPI.Domain.SeedWork;
using AnimeListAPI.Infrastructure;
using AnimeListAPI.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AnimeListAPIContext>(options =>
{
    options.UseInMemoryDatabase("AnimeListDb");
});

builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<ILanguageRepository, LanguageRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ISeriesRepository, SeriesRepository>();
builder.Services.AddTransient<IStudioRepository, StudioRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(GetAllCountriesQueryHandler).Assembly);


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

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
