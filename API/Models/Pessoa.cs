namespace API.Models;

public class Pessoa

{
    public int PessoaId { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }

    // Relação de um para muitos com Telefone
    public ICollection<Telefone> Telefones { get; set; }
}

