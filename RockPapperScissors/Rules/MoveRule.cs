namespace RockPaperScissors.Rules
{
	using Interface;


	/// <summary>
	/// Concrete class used to implement <see cref="IMoveRule"/>.
	/// </summary>
	public class MoveRule : IInitializeMoveRule
	{
		private readonly string name;

		private HashSet<IMoveRule> winningMoves;
		private HashSet<IMoveRule> losingMoves;


		public string Name => name;


		public MoveRule(string name)
		{
			this.name = name;
		}


		RoundResult IMoveRule.DetermineWinner(IMoveRule opposingMove)
		{
			if(winningMoves.Contains(opposingMove))
				return RoundResult.SUCCESS;
			if(losingMoves.Contains(opposingMove))
				return RoundResult.FAILURE;

			return RoundResult.DRAW;
		}

		IInitializeMoveRule IInitializeMoveRule.Initialize(
			IEnumerable<IMoveRule> winningMoves,
			IEnumerable<IMoveRule> losingMoves)
		{
			this.winningMoves = winningMoves.ToHashSet();
			this.losingMoves = losingMoves.ToHashSet();

			return this;
		}
	}
}