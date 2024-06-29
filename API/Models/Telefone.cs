using API.Models;
using API.Services;
using System.ComponentModel.DataAnnotations;

namespace API;

public class Telefone
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O tipo de telefone é obrigatório.")]
    public TipoTelefone Tipo { get; set; } // Celular, Residencial, Comercial
    
    [Required(ErrorMessage = "O número de telefone é obrigatório.")]
    [PhoneValidation(ErrorMessage = "O formato do número de telefone é inválido.")]
     public string Numero { get; set; }

    // Chave estrangeira para a classe Pessoa
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}


public enum TipoTelefone
{
    Residencial,
    Comercial,
    Celular
}
