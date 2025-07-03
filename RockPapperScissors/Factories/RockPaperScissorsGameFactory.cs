namespace RockPaperScissors.Factories
{
	using Interface;
	using Rules;
	using Rules.Interface;


	/// <summary>
	/// Factory used to create the move rules in RockPaperScissors.
	/// </summary>
	public class RockPaperScissorsGameFactory : IFactory<IReadOnlyList<IMoveRule>>
	{
		public IReadOnlyList<IMoveRule> Create()
		{
			var rock = new MoveRule("Rock") as IInitializeMoveRule;
			var papper = new MoveRule("Paper") as IInitializeMoveRule;
			var scissors = new MoveRule("Scissors") as IInitializeMoveRule;


			return new List<IMoveRule>()
			{
				rock.Initialize(
					winningMoves : new[] { scissors },
					losingMoves : new[] { papper } ),
				papper.Initialize(
					winningMoves : new[] { rock },
					losingMoves : new[] { scissors }),
				scissors.Initialize(
					winningMoves : new[] { papper },
					losingMoves : new[] { rock })
			};
		}
	}
}