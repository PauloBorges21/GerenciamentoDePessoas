using GerenciamentoDePessoas.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDePessoas.Models
{

    public class Pessoa
    {
        //public Pessoa()
        //{
        //}

        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "O nome deve ser maior que 2 e menor que 10")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O sobrenome dever ser maior que 2 e menor que 20")]
        public string? Sobrenome { get; set; }

        [CustomValidation(typeof(Pessoa), "ValidarDataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O cpf dever conter 11 digitos")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O tipo sanguineo é obrigatório")]
        public ETipoSanguineo TipoSanguineo { get; set; }

        public static ValidationResult ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Now)
            {
                return new ValidationResult("Data de nascimento inválida");
            }

            return ValidationResult.Success;

        }


    }
}
