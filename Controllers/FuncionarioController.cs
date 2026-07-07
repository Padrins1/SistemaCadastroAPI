using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCadastroAPI.Data;
using SistemaCadastroAPI.Models;

namespace SistemaCadastroAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Funcionarios.ToList());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = funcionario.Id }, funcionario);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

        if (funcionario == null)
            return NotFound();

        return Ok(funcionario);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveById(int id)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

        if (funcionario == null)
            return NotFound();

        _context.Funcionarios.Remove(funcionario);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Funcionario funcionarioAtualizado)
    {
        var funcionario = (_context.Funcionarios.FirstOrDefault(f =>f.Id == id));

        if (funcionario == null)
            return NotFound();

        funcionario.Nome = funcionarioAtualizado.Nome;
        funcionario.Cpf = funcionarioAtualizado.Cpf;
        funcionario.Cargo = funcionarioAtualizado.Cargo;
        funcionario.Salario = funcionarioAtualizado.Salario;
        funcionario.Idade = funcionarioAtualizado.Idade;

        _context.SaveChanges();
        return NoContent();
    }
}