namespace RockPaperScissors.Factories
{
	using Interface;
	using Rules;
	using Rules.Interface;


	/// <summary>
	/// Factory used to create the move rules in the Spock version of RockPaperScissors.
	/// </summary>
	public class SpockGameFactory : IFactory<IReadOnlyList<IMoveRule>>
	{
		public IReadOnlyList<IMoveRule> Create()
		{
			var rock = new MoveRule("Rock") as IInitializeMoveRule;
			var papper = new MoveRule("Paper") as IInitializeMoveRule;
			var scissors = new MoveRule("Scissors") as IInitializeMoveRule;
			var spock = new MoveRule("Spock") as IInitializeMoveRule;
			var lizard = new MoveRule("Lizard") as IInitializeMoveRule;


			return new List<IMoveRule>()
			{
				rock.Initialize(
					winningMoves : new[] { scissors, lizard },
					losingMoves : new [] { papper, spock } ),
				papper.Initialize(
					winningMoves : new[] { rock, spock },
					losingMoves : new[] { scissors, lizard }),
				scissors.Initialize(
					winningMoves : new[] { papper, lizard },
					losingMoves : new[] { rock, spock }),
				spock.Initialize(
					winningMoves : new[] { scissors, rock },
					losingMoves : new[] { papper, lizard }),
				lizard.Initialize(
					winningMoves : new[] {papper, spock },
					losingMoves : new[] {rock, scissors })
			};
		}
	}
}