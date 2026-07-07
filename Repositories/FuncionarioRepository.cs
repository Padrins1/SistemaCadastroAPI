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

        public List<Funcionario> GetAll()
        {
            return _context.Funcionarios.ToList();
        }

        public Funcionario? GetById(int id)
        {
            return _context.Funcionarios.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public void Update(Funcionario funcionario)
        {
            _context.SaveChanges();
        }

        public void Remove(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }
    }
}