using MenuLib;

namespace Class.MenuImplementation;

public class PlayMenu : Menu
{
    public PlayMenu() : base("Play")
    {
        ConfigureOptions(1);
        AddOption("1", "Say Hello World");
    }

    protected override NavigationResult HandleOption(string option)
    {
        switch (option)
        {
            case "1":
                Console.WriteLine("Hello World!");
                return NavigationResult.Wait();
        }

        return NavigationResult.None();
    }
}