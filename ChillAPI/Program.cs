using DataAccesService;
using DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChillApplicationContext>(options => options.UseSqlServer("Server=.;Database=ChillApplicationContext-04f542cb-7874-4345-a660-3d82a7e52118;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<DAS>();

var app = builder.Build();