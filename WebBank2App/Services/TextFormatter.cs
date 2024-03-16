using System.Text.RegularExpressions;

namespace WebBank2App.Services
{
    public class TextFormatter
    {
        public string FormatCardNumber(string cardNumber)
        {
            return Regex.Replace(cardNumber, @"(\d{4})(\d{4})(\d{4})(\d{4})", "$1 $2 $3 $4"); ;
        }
    }
}
