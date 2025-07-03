namespace RockPaperScissors.Rules.Interface
{
	/// <summary>
	/// Interface used to initialize a moves winning and losing moves.
	/// </summary>
	public interface IInitializeMoveRule : IMoveRule
	{
		/// <summary>
		/// Initialize the set of winning and losing moves.
		/// </summary>
		/// <param name="winningMoves">The moves that this will win against.</param>
		/// <param name="losingMoves">The moves that this will lose against.</param>
		/// <returns>The initialized move rule.</returns>
		public IInitializeMoveRule Initialize(
			IEnumerable<IMoveRule> winningMoves,
			IEnumerable<IMoveRule> losingMoves);
	}
}