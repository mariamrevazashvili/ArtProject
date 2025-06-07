using ArtProject.Database;
using ArtProject.Decorator;
using ArtProject.IServices;
using ArtProject.Repository;
using ArtProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ArtDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IArtRepository, ArtRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IGenreService, GenreService>();
//builder.Services.AddScoped<IArtService, ArtService>();
builder.Services.AddScoped<ArtService>();
builder.Services.AddScoped<IArtService>(provider =>
{
    var realService = provider.GetRequiredService<ArtService>();
    return new ArtServiceCacheDecorator(realService);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
