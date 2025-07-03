namespace RockPaperScissors.Interface
{
	/// <summary>
	/// Generic factory used to create a new instance of T
	/// </summary>
	/// <typeparam name="T">The newly created object type</typeparam>
	public interface IFactory<T>
	{
		/// <summary>
		/// Creates a new instance of T
		/// </summary>
		/// <returns>New instance of T</returns>
		public T Create();
	}
}