using System.ComponentModel.DataAnnotations;

namespace API.Services;

public class PessoaService : ServiceCollection
{
    public class ValidarDataNascimentoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dataNascimento = (DateTime)value;

        if (dataNascimento > DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

}
