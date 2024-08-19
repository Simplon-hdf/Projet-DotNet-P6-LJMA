using System.ComponentModel.DataAnnotations;
using Projet_DotNet_P6_LJMA.Shared.Validators;

namespace Projet_DotNet_P6_LJMA.Shared.Attributes
{
    public class EmailAdressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
            => value == null || EmailValidator.IsValidEmail(value.ToString()!)
            ? ValidationResult.Success!
            : new ValidationResult("L'adresse email n'est pas valide.");
    }
}
