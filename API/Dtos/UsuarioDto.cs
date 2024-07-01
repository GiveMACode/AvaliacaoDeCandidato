using System;
using System.ComponentModel.DataAnnotations;

public class UsuarioDto
{
    [Required]
    public string NomeUsuario { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }
}
