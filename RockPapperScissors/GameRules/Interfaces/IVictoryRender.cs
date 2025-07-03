namespace RockPaperScissors.GameRules.Interfaces
{
	using Rules.Interface;


	/// <summary>
	/// Interface used to display the results of a round.
	/// </summary>
	public interface IVictoryRender
	{
		/// <summary>
		/// Displays the results of a round.
		/// </summary>
		/// <param name="playerMoves">The set of player name to move taken.</param>
		/// <returns></returns>
		public void ShowResults(IReadOnlyList<(string name, IMoveRule move)> playerMoves);
	}
}