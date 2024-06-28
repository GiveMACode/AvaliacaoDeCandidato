using System.Xml;

namespace API.Models;

public class Pessoa
{   
    //Construtor para definir Id como GUID autogenerate e ToString,
    //definicao da logica para o atributo EstaAtivo para quando for criado 
    public Pessoa()
    {
        Telefones = new List<Telefone>();
        EstaAtivo = true; 
    }

    public Guid PessoaId { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }
    // Relação de um para muitos com Telefone
    public ICollection<Telefone> Telefones { get; set; }

    //metodo para atualizacao de informacoes da classe Pessoa s/ Telefone
    public void Atualizar(string nome, string cpf, DateTime dataNascimento, Telefone telefone)
    {
     nome = Nome;
     cpf = CPF;
     dataNascimento = DataNascimento;   
    }
    //exclusao logica
    public void Deletar()
    {
        EstaAtivo = false;
    }
}

