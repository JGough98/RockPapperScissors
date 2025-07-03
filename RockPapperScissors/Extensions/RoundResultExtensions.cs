namespace RockPaperScissors.Extensions
{
	using Rules;


	/// <summary>
	/// Extension methods for the enum <see cref="RoundResult"/>.
	/// </summary>
	public static class RoundResultExtensions
	{
		/// <summary>
		/// Converts the <see cref="RoundResult"/> too a textual response.
		/// </summary>
		/// <param name="roundResult">The determined end of round result.</param>
		/// <param name="resultPlayer">The player name the result refers too.</param>
		/// <param name="otherPlayers">The set of other players the result infers against.</param>
		/// <returns></returns>
		public static string ToSinglePlayerTextResult(
			this RoundResult roundResult,
			string resultPlayer,
			params string [] otherPlayers)
			=> $"Player {resultPlayer} {roundResult.PlayerTextResult(otherPlayers)}";

		/// <summary>
		/// Converts the <see cref="RoundResult"/> too a textual response.
		/// </summary>
		/// <param name="roundResult">The determined end of round result.</param>
		/// <param name="otherPlayers">The set of other players the result infers against.</param>
		/// <returns></returns>
		public static string PlayerTextResult(
			this RoundResult roundResult,
			params string[] otherPlayers)
		{
			var opponentName = ArggregateNames(otherPlayers);

			switch (roundResult)
			{
				case RoundResult.SUCCESS:
					return $"won against {opponentName}";
				case RoundResult.DRAW:
					return $"drew against {opponentName}";
				case RoundResult.FAILURE:
					return $"lost too {opponentName}";
			}

			return "";
		}


		/// <summary>
		/// Combines sets of names together.
		/// </summary>
		/// <param name="names">The set of names to be combined together.</param>
		/// <returns>A combined set of names.</returns>
		private static string ArggregateNames(string[] names)
		{
			if (names.Length == 1)
				return names[0];
			if (names.Length == 2)
				return $"{names[0]} and {names[1]}";

			var aggregateName = names[0];

			for (var i = 1; i < names.Length - 1; i++)
				aggregateName += $", {names[i]}";

			aggregateName += $" and {names[names.Length-1]}";

			return aggregateName;
		}
	}
}