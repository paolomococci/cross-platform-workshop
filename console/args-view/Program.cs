using static System.Console;

namespace Arguments {
    class Program {
        static void Main(string[] args) {
            WriteLine($"There are {args.Length} arguments.");

            if (args.Length != 2) {
                WriteLine("to this application you need to pass two arguments");
                WriteLine("for example: dotnet run green blue");
                return;
            }

            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[0],
                ignoreCase: true
            );
            BackgroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[1],
                ignoreCase: true
            );

            WriteLine(($"foreground color: {ForegroundColor}"));
            WriteLine(($"background color: {BackgroundColor}"));
            WriteLine((""));
        }
    }
}
