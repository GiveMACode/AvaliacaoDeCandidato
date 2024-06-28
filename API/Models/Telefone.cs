using API.Models;

namespace API;

public class Telefone
{
    public Guid Id { get; set; }
    public string Tipo { get; set; } // Celular, Residencial, Comercial
    public string Numero { get; set; }

    // Chave estrangeira para a classe Pessoa
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
