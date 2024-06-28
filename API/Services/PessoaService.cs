using System.ComponentModel.DataAnnotations;

namespace API.Services;

public class PessoaService : ServiceCollection
{
    //Validar Data de Nascimento
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

    //LÓGICA DE VALIDACAO DE CPF
    public static class ValidarCPF
    {
        public static bool Validar(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !long.TryParse(cpf, out long result))
                return false;

            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            string digit = remainder.ToString();
            tempCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            digit += remainder.ToString();

            return cpf.EndsWith(digit);
        }
    }
    //
    public class ValidarCPFAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string cpf = value as string;

        if (cpf == null)
            return false;

        return ValidarCPF.Validar(cpf);
    }
}
}

