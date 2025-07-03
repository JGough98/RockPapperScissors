namespace RockPaperScissors.Players
{
	using Interfaces;
	using Rules.Interface;


	/// <summary>
	/// Computer player in which randomly selects a move from the move list.
	/// </summary>
	public class ComputerPlayerRandom : IPlayer
	{
		private readonly string name;

		private readonly IReadOnlyList<IMoveRule> moveRules;

		private readonly Random random;


		public event PlayerActionTaken OnPlayerActionTaken;


		public string Name => name;


		public ComputerPlayerRandom(
			string name,
			IReadOnlyList<IMoveRule> moveRules)
		{
			this.name = name;
			this.moveRules = moveRules;
			random = new Random();
		}


		IMoveRule IPlayer.GetNextAction()
		{
			var nextAction = moveRules[random.Next(moveRules.Count)];
			OnPlayerActionTaken?.Invoke(nextAction);

			return nextAction;
		}
	}
}