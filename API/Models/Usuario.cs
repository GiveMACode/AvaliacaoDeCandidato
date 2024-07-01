using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Usuario
{
    public Guid id { get; set; }
    
    [MinLength(6, ErrorMessage = "O username deve ter no mínimo 6 caracteres!")]
    [MaxLength(16, ErrorMessage = "O username deve ter no máximo 16 caracteres!")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string NomeUsuario { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    [MaxLength(16, ErrorMessage = "A senha não pode ter mais de 16 caracteres.")]
    public string Senha { get; set; }
    public bool EstaAtivo { get; set; }
    public bool Logado { get; set; }
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
