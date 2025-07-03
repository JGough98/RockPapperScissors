namespace RockPaperScissors.GameRules
{
	using Extensions;
	using Interfaces;
	using Rules;
	using Rules.Interface;


	public class MultiPlayerRender : IVictoryRender
	{
		public void ShowResults(
			IReadOnlyList<(string name, IMoveRule move)> players)
		{
			var playerResults = GetPlayerResults(players);

			foreach(var playerResult in playerResults)
			{
				Console.WriteLine(playerResult);
			}
		}


		private IEnumerable<string> GetPlayerResults(
			IReadOnlyList<(string name, IMoveRule move)> players)
		{
			for(var i = 0; i < players.Count; i++)
			{
				yield return GetPlayerResult(players, i);
			}
		}

		private string GetPlayerResult(
			IReadOnlyList<(string name, IMoveRule move)> players,
			int playerIndex)
		{
			var resultToPlayers = new Dictionary<RoundResult, List<string>>();
			var player = players[playerIndex];

			for (var i = 0; i < players.Count; i++)
			{
				if (i == playerIndex)
					continue;

				var nextPlayer = players[i];
				var nextResult = player.move.DetermineWinner(nextPlayer.move);

				if (!resultToPlayers.ContainsKey(nextResult))
					resultToPlayers[nextResult] = new List<string>();

				resultToPlayers[nextResult].Add(nextPlayer.name);
			}

			var firstResult = resultToPlayers.First();
			var resultText = firstResult.Key.ToSinglePlayerTextResult(
				player.name,
				firstResult.Value.ToArray());

			if(resultToPlayers.Count() == 1)
				return resultText;

			var allGroupedResults = resultToPlayers.ToArray();
			for (var i = 1; i < allGroupedResults.Length; i++)
			{
				var nextPlayer = allGroupedResults[i];
				resultText += $" and {nextPlayer.Key.PlayerTextResult(nextPlayer.Value.ToArray())}";
			}

			return resultText;
		}
	}
}