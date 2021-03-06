﻿using System.Text.RegularExpressions;
using static BinaryFog.NameParser.RegexNameComponents;

namespace BinaryFog.NameParser.Patterns {
	internal class TitleFirstLastSuffixPattern : IPattern {
		private static readonly Regex Rx = new Regex(
			@"^" + Title + Space + First + Space + Last + OptionalCommaSpace + Suffix + @"$",
			RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public ParsedName Parse(string rawName) {
			var match = Rx.Match(rawName);
			if (!match.Success) return null;
            var pn = new ParsedName(this.GetType().Name)
            {
                Title = match.Groups["title"].Value,
				FirstName = match.Groups["first"].Value,
				LastName = match.Groups["last"].Value,
				DisplayName = $"{match.Groups["first"].Value} {match.Groups["last"].Value}",
				Suffix = match.Groups["suffix"].Value,
				Score = 200
			};
			return pn;
		}
	}
}
