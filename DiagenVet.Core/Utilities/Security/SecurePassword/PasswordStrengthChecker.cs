using System.Text.RegularExpressions;

namespace DiagenVet.Core.Utilities.Security.SecurePassword
{
    public static class PasswordStrengthChecker
    {
        public static (bool isValid, string message) ValidatePassword(string password)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(password))
                return (false, "Şifre boş olamaz.");

            if (password.Length < 8)
                errors.Add("Şifre en az 8 karakter uzunluğunda olmalıdır.");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                errors.Add("Şifre en az bir büyük harf içermelidir.");

            if (!Regex.IsMatch(password, @"[a-z]"))
                errors.Add("Şifre en az bir küçük harf içermelidir.");

            if (!Regex.IsMatch(password, @"[0-9]"))
                errors.Add("Şifre en az bir rakam içermelidir.");

            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]"))
                errors.Add("Şifre en az bir özel karakter içermelidir.");

            return errors.Count == 0 
                ? (true, "Şifre geçerli.") 
                : (false, string.Join(" ", errors));
        }
    }
} 