
using APITeste.Controllers;
using APITeste.DataBase;
using APITeste.Model;
using APITeste.Repository;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using QuestPDF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoInterface,ProdutoRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Settings.License = LicenseType.Community;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
