using System.ComponentModel.DataAnnotations;

namespace API.Services;

public class TelefoneService : ServiceCollection
{
}
public class PhoneValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var contato = (Telefone)validationContext.ObjectInstance;

        if (contato.Numero == null)
            return new ValidationResult("O número de telefone é obrigatório.");

        string pattern = contato.Tipo switch
        {
            TipoTelefone.Residencial => @"^\(\d{2}\) \d{4}-\d{4}$",  // Exemplo: (12) 1234-5678
            TipoTelefone.Comercial => @"^\(\d{2}\) \d{4}-\d{4}$",     // Exemplo: (12) 1234-5678
            TipoTelefone.Celular => @"^\(\d{2}\) \d{5}-\d{4}$",       // Exemplo: (12) 91234-5678
            _ => throw new ArgumentOutOfRangeException()
        };

        if (!System.Text.RegularExpressions.Regex.IsMatch(contato.Numero, pattern))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}

