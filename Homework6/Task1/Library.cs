namespace Task1;

public class Library {
    public delegate void Visit(string name);

    private event Visit StaySubscribers;
    private event Visit OnceSubscribers;
    private int _deskCount;

    public void Subscribe(Visit handler) => StaySubscribers += handler;
    public void SubscribeOnce(Visit handler) => OnceSubscribers += handler;
    public void Unsubscribe(Visit handler) => StaySubscribers -= handler;

    public void Enter(string name) {
        if (StaySubscribers != null)
            StaySubscribers.Invoke(name);

        if (OnceSubscribers != null) {
            Visit tempOnce = OnceSubscribers;
            OnceSubscribers = null;
            tempOnce(name);
        }
    }
    
    public void Chime(string name) => Console.WriteLine($"chime {name}");
    public void Desk(string name) {
        _deskCount++;
        Console.WriteLine($"{_deskCount} {name}");
    }

    public void Slip(string name) => Console.WriteLine($"slip {name}");
    public void Card(string name) => Console.WriteLine($"card {name}");
    public void Hold(string name) => Console.WriteLine($"hold {name}");
}