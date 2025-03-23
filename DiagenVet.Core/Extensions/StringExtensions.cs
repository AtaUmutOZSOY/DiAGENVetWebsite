using System.Text.RegularExpressions;

namespace DiagenVet.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToSeoUrl(this string text)
        {
            var result = text.ToLower();
            result = result.Replace("ı", "i");
            result = result.Replace("ğ", "g");
            result = result.Replace("ü", "u");
            result = result.Replace("ş", "s");
            result = result.Replace("ö", "o");
            result = result.Replace("ç", "c");
            result = result.Replace(" ", "-");
            result = result.Replace(".", "");
            result = result.Replace("'", "");
            result = result.Replace("\"", "");
            result = result.Replace("â", "a");
            result = result.Replace("î", "i");
            result = result.Replace("ı", "i");
            result = result.Replace("İ", "I");
            result = Regex.Replace(result, @"[^a-zA-Z0-9\-]", "");
            return result;
        }

        public static bool IsValidEmail(this string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
} 