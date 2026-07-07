namespace SistemaCadastroAPI.DTOs;

public class FuncionarioResponseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public int Idade { get; set; }
}