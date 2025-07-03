namespace RockPaperScissors.Render
{
	public static class RenderToConsoleUtility
	{
		public static void Render(params string[] lines)
		{
			foreach (var line in lines)
				Console.WriteLine(line);
		}

		public static string ReadString(string title)
		{
			Console.WriteLine(title);
			return Console.ReadLine();
		}

		public static int ReadInt(string title)
		{
			var line = "";
			var option = 0;

			do
			{
				Console.WriteLine(title);

				line = Console.ReadLine();
			}
			while (!int.TryParse(line, out option) || option < 0);

			return option;
		}

		public static int ReadOptions(RenderOptions renderOptions)
		{
			var line = "";
			var option = 0;

			do
			{
				Console.WriteLine(renderOptions.Title);
				for (var i = 0; i < renderOptions.Options.Count; i++)
					Console.WriteLine($"{i}) {renderOptions.Options[i]}");

				line = Console.ReadLine();
			}
			while (!int.TryParse(line, out option) || option >= renderOptions.Options.Count || option < 0);

			return option;
		}
	}
}