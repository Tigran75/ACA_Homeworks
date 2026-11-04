namespace Task1;

class Program {
    static void Main(string[] args) {
        Library library = new Library();

        library.Subscribe(library.Chime);
        library.Subscribe(library.Desk);
        library.SubscribeOnce(library.Slip);
        library.SubscribeOnce(library.Card);
        library.Enter("Ana");
        Console.WriteLine();
        library.Enter("Leo");
        Console.WriteLine();
        library.Unsubscribe(library.Desk);
        library.SubscribeOnce(library.Hold);
        library.Enter("Mia");
    }
}