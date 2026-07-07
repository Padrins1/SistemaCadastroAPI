using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroAPI.Models;

public class Funcionario
{
    public Funcionario(string nome, string cpf, string cargo, decimal salario, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Cargo = cargo;
        Salario = salario;
        Idade = idade;
    }

    public int Id { get; set; }
    public string Nome {  get; set; }
    public string Cpf { get; set; }
    public string Cargo { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salario { get; set; }
    public int Idade { get; set; }

}
