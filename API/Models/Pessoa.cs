namespace API.Models;

public class Pessoa
{   
    //Construtor para definir Id como GUID autogenerate e ToString,
    //definicao da logica para o atributo EstaAtivo para quando for criado 
    public Pessoa()
    {
        PessoaId = Guid.NewGuid().ToString();
        EstaAtivo = true;
    }

    public string PessoaId { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }
    // Relação de um para muitos com Telefone
    public ICollection<Telefone> Telefones { get; set; }

    //metodo para atualizacao de informacoes da classe Pessoa s/ Telefone
    public void Update(string nome, string cpf, DateTime dataNascimento)
    {
     nome = Nome;
     cpf = CPF;
     dataNascimento = DataNascimento;   
    }
    //exclusao logica
    public void Delete()
    {
        EstaAtivo = false;
    }

}

