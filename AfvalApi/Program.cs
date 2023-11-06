using DataAccessService;
using DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChillApplicationContext>(options => options.UseSqlServer("Server=.;Database=ChillApplicationContext-04f542cb-7874-4345-a660-3d82a7e52118;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<DAS>();

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
