namespace RockPaperScissors.Rules.Interface
{
	/// <summary>
	/// Interface used to retrieve the <see cref="RoundResult"/> between two moves.
	/// </summary>
	public interface IMoveRule
	{
		/// <summary>
		/// Retrieves the name of the Rule
		/// </summary>
		public string Name
		{
			get;
		}

		/// <summary>
		/// Determines the <see cref="RoundResult"/> between two moves.
		/// </summary>
		/// <param name="opposingMove">The other move to compare against.</param>
		/// <returns>The <see cref="RoundResult"/> stating if this player won. </returns>
		public RoundResult DetermineWinner(IMoveRule opposingMove);
	}
}