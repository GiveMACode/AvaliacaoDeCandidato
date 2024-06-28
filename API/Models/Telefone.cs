using API.Models;

namespace API;

public class Telefone
{
    public Guid TelefoneId { get; set; }
    public string Tipo { get; set; } // Celular, Residencial, Comercial
    public string Numero { get; set; }

    // Chave estrangeira para a classe Pessoa
    public string PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
