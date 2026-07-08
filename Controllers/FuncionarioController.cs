using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroAPI.DTOs;
using SistemaCadastroAPI.Models;
using SistemaCadastroAPI.Services;

namespace SistemaCadastroAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _service;

    public FuncionarioController(FuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var funcionarios = (await _service.GetAll())
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
    public async Task<IActionResult> Create([FromBody] FuncionarioCreateDTO dto)
    {
        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Cargo = dto.Cargo,
            Salario = dto.Salario,
            Idade = dto.Idade
        };

        await _service.Add(funcionario);
        return CreatedAtAction(nameof(GetAll), new { id = funcionario.Id }, funcionario);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var funcionario = await _service.GetById(id);
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
    public async Task<IActionResult> RemoveById(int id)
    {
        var funcionario = await _service.GetById(id);
        if (funcionario == null)
            return NotFound();

        await _service.Remove(funcionario);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] FuncionarioCreateDTO dto)
    {
        var funcionario = await _service.GetById(id);
        if (funcionario == null)
            return NotFound();

        funcionario.Nome = dto.Nome;
        funcionario.Cpf = dto.Cpf;
        funcionario.Cargo = dto.Cargo;
        funcionario.Salario = dto.Salario;
        funcionario.Idade = dto.Idade;

        await _service.Update(funcionario);
        return NoContent();
    }
}