// See https://aka.ms/new-console-template for more information

using System.Reflection;

if (args.Length == 0)
{
	var assembly = Assembly.GetExecutingAssembly().ManifestModule.Name;
	var app = assembly.Substring(0, assembly.LastIndexOf('.'));

	Console.WriteLine();
	Console.WriteLine(app);
	Console.WriteLine();
	Console.Write("Usage: ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write(app);
	Console.ResetColor();
	Console.Write(" (");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("find replace");
	Console.ResetColor();
	Console.Write(")n [");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("filter");
	Console.ResetColor();
	Console.WriteLine("]");
	Console.WriteLine();
	Console.WriteLine("Rename all files in the current directory.");
	Console.WriteLine();
	Console.Write("Replace ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("find");
	Console.ResetColor();
	Console.Write(" with ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("replace");
	Console.ResetColor();
	Console.WriteLine(" in filenames for 1 or more quoted-string pairs.");
	Console.Write("If specified, use an optional file ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("filter");
	Console.ResetColor();
	Console.Write(" glob; otherwise default to ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("IMG*.jpg");
	Console.ResetColor();
	Console.WriteLine();

	Environment.Exit(1);
}

var glob = (args.Length % 2 == 1) ? args[^1] : "IMG*.jpg";
var files = Directory.EnumerateFiles(Environment.CurrentDirectory, glob);

for (int i = 0; i < args.Length - 1; i += 2)
{
	var findStr = args[i]; // "IMG20231104"
	var replaceStr = args[i + 1]; // "Cardiff Solidarity for Palestine protest, 4 November 2023 "

	foreach (var file in files)
	{
		var newName = file.Replace(findStr, replaceStr);

		if (file != newName)
		{
			Console.Write("Moving ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(file.Substring(file.LastIndexOf('\\') + 1));
			Console.ResetColor();
			Console.Write(" to ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(newName.Substring(newName.LastIndexOf('\\') + 1));
			Console.ResetColor();
			Console.WriteLine("...");

			File.Move(file, newName);
		}
	}
}
