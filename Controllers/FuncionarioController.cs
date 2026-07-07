using Microsoft.AspNetCore.Mvc;
using SistemaCadastroAPI.DTOs;
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
        var funcionarios = _service.GetAll()
            .Select(f => new FuncionarioResponseDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Cargo = f.Cargo,
                Salario = f.Salario,
                Idade = f.Idade
            });

        return Ok(funcionarios);
    }

    [HttpPost]
    public IActionResult Create([FromBody] FuncionarioCreateDTO dto)
    {
        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Cargo = dto.Cargo,
            Salario = dto.Salario,
            Idade = dto.Idade
        };

        _service.Add(funcionario);
        return CreatedAtAction(nameof(GetAll), new { id = funcionario.Id }, funcionario);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var funcionario = _service.GetById(id);
        if (funcionario == null)
            return NotFound();

        var dto = new FuncionarioResponseDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Salario = funcionario.Salario,
            Idade = funcionario.Idade
        };

        return Ok(dto);
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
    public IActionResult Atualizar(int id, [FromBody] FuncionarioCreateDTO dto)
    {
        var funcionario = _service.GetById(id);
        if (funcionario == null)
            return NotFound();

        funcionario.Nome = dto.Nome;
        funcionario.Cpf = dto.Cpf;
        funcionario.Cargo = dto.Cargo;
        funcionario.Salario = dto.Salario;
        funcionario.Idade = dto.Idade;

        _service.Update(funcionario);
        return NoContent();
    }
}