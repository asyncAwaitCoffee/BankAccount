﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace WebBank2App.Models
{
	public record class CardModel(string Code, int AccountId, int UserId, int BankId, string Type, DateOnly Date)
	{
		private static int idCounter = 0;
		public int Id { get; init; } = ++idCounter;
    }
}
