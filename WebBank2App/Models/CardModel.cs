using System.Globalization;
using System.Text.RegularExpressions;

namespace WebBank2App.Models
{
	public record class CardModel(string Code, int AccountId, int UserId, int BankId, string Type, DateOnly Date)
	{
		private static int idCounter = 0;
		public int Id { get; init; } = ++idCounter;
        public string ValidThru { get { return Date.ToString("MM/yy", CultureInfo.InvariantCulture); } }
		public string FormattedCode { get {
				return Regex.Replace(Code, @"(\d{4})(\d{4})(\d{4})(\d{4})", "$1 $2 $3 $4");
			} }
    }
}
