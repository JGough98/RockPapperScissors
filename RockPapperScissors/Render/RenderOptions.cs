namespace RockPaperScissors.Render
{
	public struct RenderOptions
	{
		public string Title
		{
			get;
		}

		public IReadOnlyList<string> Options
		{
			get;
		}


		public RenderOptions(string title, List<string> options)
		{
			Title = title;
			Options = options;
		}
	}
}