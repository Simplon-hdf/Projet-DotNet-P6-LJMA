using System.ComponentModel.DataAnnotations;
using Projet_DotNet_P6_LJMA.Shared.Validators;

namespace Projet_DotNet_P6_LJMA.Shared.Attributes
{
    public class ComplexPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
            => value == null || PasswordValidator.IsValidPassword(value.ToString()!)
            ? ValidationResult.Success!
            : new ValidationResult("Le mot de passe doit contenir au moins une majuscule, une minuscule, un chiffre et un caractère spécial.");
    }
}
