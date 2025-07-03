namespace RockPaperScissors
{
	using Factories;
	using GameRules;
	using Interface;
	using Players.Interfaces;
	using Players;
	using Render;
	using Rules.Interface;


	public class GameController
	{
		private readonly RenderOptions choosePlayer = new RenderOptions(
			"Choose Players",
			new List<string>()
			{
				"2 Player",
				"3 Player"
			});

		private readonly RenderOptions chooseGameMode = new RenderOptions(
			"Choose Game Mode",
			new List<string>()
			{
				"Rock Paper Scissors",
				"Spock Lizard Rock Paper Scissors"
			});


		public void PlayGame()
		{
			var playerName = PlayerNameSelect();
			var gameMode = ChooseGameMode();
			var board = SetupPlayers(gameMode, playerName);
			var rounds = SetRounds();

			for (var i = 0; i < rounds; i++)
				board.PlayNextRound();
		}


		private Board SetupPlayers(
			IFactory<IReadOnlyList<IMoveRule>> gameMode,
			string playerName)
		{
			var board = new Board();

			var selectedOption = RenderToConsoleUtility.ReadOptions(choosePlayer);

			var rules = gameMode.Create();

			var humanPlayer = new HumanPlayer(
				playerName,
				rules);
			var computerPlayerOne = new ComputerPlayerRandom(
				"ComputerOne",
				rules);

			if (selectedOption == 0)
			{
				board.InitializeRules(new TwoPlayerRender());
				board.InitializePlayers(new IPlayer[]
				{
					humanPlayer,
					computerPlayerOne,
				});
			}
			else
			{
				board.InitializeRules(new MultiPlayerRender());
				board.InitializePlayers(new IPlayer[]
				{
					computerPlayerOne,
					new ComputerPlayerCopyCat(
						"ComputerTwo",
						(computerPlayerOne as IPlayer).GetNextAction(),
						humanPlayer),
					humanPlayer,
				});
			}

			return board;
		}

		private static string PlayerNameSelect()
			=> RenderToConsoleUtility.ReadString("Enter your name.");

		private static int SetRounds()
			=> RenderToConsoleUtility.ReadInt("Select rounds played.");

		private IFactory<IReadOnlyList<IMoveRule>> ChooseGameMode()
			=> RenderToConsoleUtility.ReadOptions(chooseGameMode) == 0
				? new RockPaperScissorsGameFactory()
				: new SpockGameFactory();
	}
}