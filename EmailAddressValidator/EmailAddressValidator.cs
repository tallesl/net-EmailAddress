using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EmailAddressValidation
{
	/// <summary>
	/// Lightly adapted from https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx
	/// </summary>
	public static class EmailAddressValidator
	{
		public static bool IsValid(string strIn)
		{
			if (string.IsNullOrEmpty(strIn))
			{
				return false;
			}

			// Use IdnMapping class to convert Unicode domain names
			var domainMapper = new DomainMapper();
			strIn = Regex.Replace(strIn, @"(@)(.+)$", domainMapper.MatchEvaluator);
			if (domainMapper.Invalid)
			{
				return false;
			}

			// Return true if strIn is in valid e-mail format
			return Regex.IsMatch(strIn,
				   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
				   RegexOptions.IgnoreCase);
		}

		private class DomainMapper
		{
			internal bool Invalid { get; private set; }

			internal DomainMapper()
			{
				Invalid = false;
			}

			internal string MatchEvaluator(Match match)
			{
				// IdnMapping class with default property values
				var idn = new IdnMapping();

				var domainName = match.Groups[2].Value;
				try
				{
					domainName = idn.GetAscii(domainName);
				}
				catch (ArgumentException)
				{
					Invalid = true;
				}
				return match.Groups[1].Value + domainName;
			}
		}
	}
}
