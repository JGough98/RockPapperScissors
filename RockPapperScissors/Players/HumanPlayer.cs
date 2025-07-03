namespace RockPaperScissors.Players
{
	using Interfaces;
	using Render;
	using Rules.Interface;


	/// <summary>
	/// Player class used to read the input of the console to interpret the players action.
	/// </summary>
	public class HumanPlayer : IPlayer
	{
		private string name;

		private Dictionary<int, IMoveRule> actionToMove;

		private RenderOptions selectMove;


		public event PlayerActionTaken OnPlayerActionTaken;


		public string Name => name;


		public HumanPlayer(
			string name,
			IReadOnlyList<IMoveRule> rules)
		{
			this.name = name;
			actionToMove = rules
				.Select((x, i) => (x, i))
				.ToDictionary(k => k.i, v => v.x);
			selectMove = new RenderOptions(
				"Select move.",
				actionToMove.Values.Select(x => x.Name).ToList());
		}


		IMoveRule IPlayer.GetNextAction()
		{
			var optionMade = actionToMove[RenderToConsoleUtility.ReadOptions(selectMove)];
			OnPlayerActionTaken?.Invoke(optionMade);
			return optionMade;
		}
	}
}