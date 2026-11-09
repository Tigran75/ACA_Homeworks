namespace MenuLib;

public static class MenuRunner {
    private static readonly MenuStack _navigationStack = new MenuStack();

    public static void Run(Menu root) {
        _navigationStack.Push(root);
        while (_navigationStack.Count > 0) {
            Menu current = _navigationStack.Peek();
            current.Display();

            Console.WriteLine();
            Console.Write("Select option: ");
            string? input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            NavigationResult result = current.ExecuteOption(input);
            switch (result.Type) {
                case NavigationResultType.None:
                    break;
                case NavigationResultType.GoTo:
                    _navigationStack.Push(result.Menu);
                    break;
                case NavigationResultType.Wait:
                    Console.WriteLine("Waiting..., Press any key to continue...");
                    Console.ReadKey();
                    break;
                case NavigationResultType.Back:
                    if (_navigationStack.Count > 1)
                        _navigationStack.Pop();
                    break;
                case NavigationResultType.Exit:
                    return;
            }
        }
    }
}