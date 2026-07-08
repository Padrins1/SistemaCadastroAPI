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

        public async Task<List<Funcionario>> GetAll() => await _repository.GetAll();
        public async Task<Funcionario?> GetById(int id) => await _repository.GetById(id);
        public async Task Add(Funcionario f) => await _repository.Add(f);
        public async Task Update(Funcionario f) => await _repository.Update(f);
        public async Task Remove(Funcionario f) => await _repository.Remove(f);
    }
}