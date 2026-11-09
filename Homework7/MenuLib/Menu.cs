namespace MenuLib;

public struct Option {
    public string Key { get; set; }
    public string Value { get; set; }

    public Option(string Key, string Value) {
        this.Key = Key;
        this.Value = Value;
    }
}

public abstract class Menu {
    public string Title { get; }
    private Option[] _options;
    private int _optionIndex;

    public Menu(string Title) {
        this.Title = Title;
    }

    protected void ConfigureOptions(int Count) {
        _options = new Option[Count];
    }

    protected void AddOption(string Key, string Value) {
        _options[_optionIndex] = new Option(Key, Value);
        _optionIndex++;
    }

    private bool ContainsOption(string Key) {
        for (int i = 0; i < _options.Length; i++)
            if(Key == _options[i].Key)
                return true;
        return false;
    }

    public void Display() {
        Console.Clear();
        Console.WriteLine($"=== {Title} ===");
        if (_options != null) {
            for (int i = 0; i < _options.Length; i++) {
                Option option = _options[i];
                Console.WriteLine($"{option.Key} {option.Value}");
            }
        }
        InternalDisplay();
        Console.WriteLine("\n --- Navigation ---");
        Console.WriteLine("Type 'back' to go back");
        Console.WriteLine("Type 'exit' to exit");
    }

    protected virtual void InternalDisplay() {
        
    }

    public NavigationResult ExecuteOption(string option) {
        if (option == "back")
            return NavigationResult.Back();
        if (option == "exit")
            return NavigationResult.Exit();
        if (ContainsOption(option)) {
            Console.Clear();
            return HandleOption(option);
        }

        Console.WriteLine("Invalid option");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return NavigationResult.None();
    }
    
    protected abstract NavigationResult HandleOption(string option);
}