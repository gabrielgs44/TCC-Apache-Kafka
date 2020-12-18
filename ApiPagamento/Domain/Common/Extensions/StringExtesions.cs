using System;
using System.Net.Mail;

namespace Domain.Common.Extensions
{
    public static class StringExtesions
    {
        public static string ToTrim(this string text) =>
            string.IsNullOrEmpty(text) ? text : text.Trim();

        public static bool IsNullOrEmpty(this string text) =>
            string.IsNullOrWhiteSpace(text);

        public static bool IsEmailValid(this string email)
        {
            try
            {
                email = email.ToTrim();
                return new MailAddress(email).Address.IsEqual(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEqual(this string text, string anotherText, bool ignoreCase = true)
        {
            if (text == null && anotherText == null)
            {
                return true;
            }
            else
            {
                if (text == null ^ anotherText == null)
                {
                    return false;
                }

                return text.Equals(anotherText, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
            }
        }
    }
}
