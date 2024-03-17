using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebBank2App.Services
{
    public class TextFormatter
    {
        public string FormatCardNumber(string cardNumber)
        {
            return Regex.Replace(cardNumber, @"(\d{4})(\d{4})(\d{4})(\d{4})", "$1 $2 $3 $4"); ;
        }
		public string FormatValidThru(DateTime date)
		{
			return date.ToString("MM/yy", CultureInfo.InvariantCulture);
		}
	}
}
