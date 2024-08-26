using System.Text.RegularExpressions;

namespace Projet_DotNet_P6_LJMA.Shared.Validators
{
    public static class PasswordValidator
    {
        private static readonly Regex PasswordRegex = new Regex(pattern: @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]).*$", options: RegexOptions.Compiled);
        public static bool IsValidPassword(string password)
            => !string.IsNullOrWhiteSpace(password) && PasswordRegex.IsMatch(password);
    }
}
