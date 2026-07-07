using Microsoft.EntityFrameworkCore;
using SistemaCadastroAPI.Data;
using SistemaCadastroAPI.Repositories;
using SistemaCadastroAPI.Services;
using SistemaCadastroAPI.Repositories;
using SistemaCadastroAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<FuncionarioRepository>();
builder.Services.AddScoped<FuncionarioService>();

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