using SistemaCadastroAPI.Models;
using SistemaCadastroAPI.Repositories;

namespace SistemaCadastroAPI.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _repository;

        public FuncionarioService(FuncionarioRepository repository)
        {
            _repository = repository;
        }

        public List<Funcionario> GetAll() => _repository.GetAll();
        public Funcionario? GetById(int id) => _repository.GetById(id);
        public void Add(Funcionario f) => _repository.Add(f);
        public void Update(Funcionario f) => _repository.Update(f);
        public void Remove(Funcionario f) => _repository.Remove(f);
    }
}