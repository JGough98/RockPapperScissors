namespace RockPaperScissors
{
	using Players.Interfaces;
	using GameRules.Interfaces;
	using Render;


	public class Board
	{
		private IReadOnlyList<IPlayer> players;

		private IVictoryRender gameRules;


		private bool IsIntialized => players.Count() > 0 && gameRules != null;


		public void InitializePlayers(
			IReadOnlyList<IPlayer> players)
			=> this.players = players;

		public void InitializeRules(
			IVictoryRender gameRules)
			=> this.gameRules = gameRules;

		public void PlayNextRound()
		{
			if (!IsIntialized)
				return;

			var playerMoves = players.Select(x => (x.Name, x.GetNextAction())).ToList();

			RenderToConsoleUtility.Render(playerMoves.Select(x => $"Player {x.Name} threw {x.Item2.Name}.").ToArray());

			gameRules.ShowResults(playerMoves);
		}
	}
}