namespace RockPaperScissors.Players
{
	using Interfaces;
	using Rules.Interface;


	/// <summary>
	/// Computer player in which copies the previous action of another player.
	/// </summary>
	public class ComputerPlayerCopyCat : IPlayer
	{
		private readonly string name;

		private IMoveRule lastMoveTaken;


		public event PlayerActionTaken OnPlayerActionTaken;


		public string Name => name;


		public ComputerPlayerCopyCat(string name, IMoveRule startingMove, IPlayer playerToCopy)
		{
			this.name = name;
			this.lastMoveTaken = startingMove;
			playerToCopy.OnPlayerActionTaken += RecordPlayersAction;
		}


		public IMoveRule GetNextAction()
		{
			OnPlayerActionTaken?.Invoke(lastMoveTaken);
			return lastMoveTaken;
		}


		private void RecordPlayersAction(IMoveRule lastMoveTaken)
		{
			this.lastMoveTaken = lastMoveTaken;
		}
	}
}
