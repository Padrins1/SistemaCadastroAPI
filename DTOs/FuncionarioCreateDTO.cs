using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroAPI.DTOs
{
    public class FuncionarioCreateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [MaxLength(14, ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Cargo é obrigatório")]
        public string Cargo { get; set; }

        [Range(0, 999999, ErrorMessage = "Salário deve ser positivo")]
        public decimal Salario { get; set; }

        [Range(16, 100, ErrorMessage = "Idade deve ser entre 16 e 100")]
        public int Idade { get; set; }
    }
}
