using Microsoft.AspNetCore.Mvc;
using SistemaCadastroAPI.Models;
using SistemaCadastroAPI.Services;

namespace SistemaCadastroAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _service;

    public FuncionarioController(FuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Funcionario funcionario)
    {
        _service.Add(funcionario);
        return CreatedAtAction(nameof(GetAll), new { id = funcionario.Id }, funcionario);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var funcionario = _service.GetById(id);
        if (funcionario == null)
            return NotFound();
        return Ok(funcionario);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveById(int id)
    {
        var funcionario = _service.GetById(id);
        if (funcionario == null)
            return NotFound();
        _service.Remove(funcionario);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Funcionario funcionarioAtualizado)
    {
        var funcionario = _service.GetById(id);
        if (funcionario == null)
            return NotFound();

        funcionario.Nome = funcionarioAtualizado.Nome;
        funcionario.Cpf = funcionarioAtualizado.Cpf;
        funcionario.Cargo = funcionarioAtualizado.Cargo;
        funcionario.Salario = funcionarioAtualizado.Salario;
        funcionario.Idade = funcionarioAtualizado.Idade;

        _service.Update(funcionario);
        return NoContent();
    }
}