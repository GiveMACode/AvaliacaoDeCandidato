using System.ComponentModel.DataAnnotations;
using System.Xml;
using static API.Services.PessoaService;

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
    public Guid Id { get; set; }

    //tratamento de requisicao
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 3 caracteres!")]
    [MaxLength(256, ErrorMessage = "O nome deve ter no máximo 256 caracteres!")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    
    
    //tratamento de CPF
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
    [ValidarCPF(ErrorMessage = "CPF inválido.")]
    public string CPF { get; set; }
    //
    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [ValidarDataNascimento(ErrorMessage = "A data de nascimento não pode ser no futuro.")]
    public DateTime DataNascimento { get; set; }


    public bool EstaAtivo { get; set; }

    // Relação de um para muitos com Telefone
    public ICollection<Telefone> Telefones { get; set; }


    //metodo para atualizacao de informacoes da classe Pessoa s/ Telefone
    public void Atualizar(string? nome, string? cpf, DateTime dataNascimento, Telefone telefone)
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

