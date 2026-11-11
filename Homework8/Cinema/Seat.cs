namespace Cinema;

public class Seat {
    private bool _taken;
    public string Code { get; }
    
    public Seat(string code) {
        Code = code;
    }

    public bool IsFree {
        get { return !_taken; }
    }

    public void Take() {
        if (_taken)
            throw new InvalidOperationException("Seat " + Code + " is taken");
        _taken = true;
    }
}