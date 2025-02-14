using Flash.Application.Dtos;
using Flash.InfraStructure.Data;
using Flash.InfraStructure.Repositories.CardRepository;
using Microsoft.EntityFrameworkCore;
using Flash.Domain.Interfaces.ICardRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
});

builder.Services.AddScoped<ICardRepository, CardRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(cors =>
{
    cors.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials().WithOrigins("http://localhost:5173");
});

app.MapControllers();



app.Run();
