namespace RockPaperScissors.Players.Interfaces
{
	using Rules.Interface;


	public delegate void PlayerActionTaken(IMoveRule actionTaken);


	/// <summary>
	/// Interface used to retrieve the next action and name of a player.
	/// </summary>
	public interface IPlayer
	{
		/// <summary>
		/// Event hook up for fetching the players taken.
		/// </summary>
		public event PlayerActionTaken OnPlayerActionTaken;


		/// <summary>
		/// The name used to represent the player.
		/// </summary>
		public string Name
		{
			get;
		}

		/// <summary>
		/// Retrieves the next action of the player.
		/// </summary>
		/// <returns>Task returning the chosen move of the player.</returns>
		IMoveRule GetNextAction();
	}
}