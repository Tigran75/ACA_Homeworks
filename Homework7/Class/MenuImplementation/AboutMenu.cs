using MenuLib;

namespace Class.MenuImplementation;

public class AboutMenu : Menu {
    public AboutMenu() : base("About") {
    }

    protected override void InternalDisplay() {
        Console.WriteLine("Made in Armenia");
        Console.WriteLine("Something awesome!");
    }

    protected override NavigationResult HandleOption(string option) {
        return NavigationResult.Wait();
    }
}