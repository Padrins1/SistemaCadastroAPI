using Microsoft.EntityFrameworkCore;
using SistemaCadastroAPI.Models;

namespace SistemaCadastroAPI.Data;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
