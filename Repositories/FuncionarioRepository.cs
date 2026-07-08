using Microsoft.EntityFrameworkCore;
using SistemaCadastroAPI.Data;
using SistemaCadastroAPI.Models;

namespace SistemaCadastroAPI.Repositories
{
    public class FuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetAll()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario?> GetById(int id)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Add(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Funcionario funcionario)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}