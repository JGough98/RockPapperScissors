namespace RockPaperScissors.GameRules
{
	using Extensions;
	using Interfaces;
	using Rules;
	using Rules.Interface;


	public class TwoPlayerRender : IVictoryRender
	{
		public void ShowResults(
			IReadOnlyList<(string name, IMoveRule move)> players)
		{
			if (players.Count != 2)
				return;

			(var playerOneName, var playerOneMove) = players.First();
			(var playerTwoName, var playerTwoMove) = players.Last();

			DisplayResults(
				playerOneName,
				playerTwoName,
				playerOneMove.DetermineWinner(playerTwoMove));
		}


		private void DisplayResults(
			string playerOneName,
			string playerTwoName,
			RoundResult playerOneResult)
		{
			var victoryName = playerOneResult.ToSinglePlayerTextResult(
				playerOneName,
				playerTwoName);

			Console.WriteLine(victoryName);
		}
	}
}