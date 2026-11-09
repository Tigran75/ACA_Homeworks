using MenuLib;

namespace Class.MenuImplementation;

public class SettingsMenu : Menu {
    public SettingsMenu() : base("Settings") {
        ConfigureOptions(2);
        AddOption("1", "Audio Settings");
        AddOption("2", "Video Settings");
    }

    protected override NavigationResult HandleOption(string option) {
        return NavigationResult.None();
    }
}