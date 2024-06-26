using API.Models;

namespace API;

public class Telefone
{
    public int TelefoneId { get; set; }
    public string Tipo { get; set; } // Celular, Residencial, Comercial
    public string Numero { get; set; }

    // Chave estrangeira para a classe Pessoa
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
