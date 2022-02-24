using AnimeList.Application;
using AnimeList.Application.Countries;
using AnimeList.Application.Genres;
using AnimeList.Application.Languages;
using AnimeList.Application.Movies;
using AnimeList.Application.Serieses;
using AnimeList.Application.Studios;
using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using AnimeList.Domain.Studios;
using AnimeList.Infrastructure;
using AnimeList.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterInfrastructureServices();
builder.Services.RegisterApplicationServices();

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
