using System.Text.RegularExpressions;

namespace Projet_DotNet_P6_LJMA.Shared.Validators
{
    public static class EmailValidator
    {
        private static readonly Regex EmailRegex = new Regex(pattern: @"^(?!.{255,}@)(?!.{65,}@)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]{1,253}\.[a-zA-Z]{2,}$", options: RegexOptions.Compiled);
        public static bool IsValidEmail(string email)
            => !string.IsNullOrWhiteSpace(email) && !(email.Length > 320) && EmailRegex.IsMatch(email);
    }
}
