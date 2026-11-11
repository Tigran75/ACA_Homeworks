namespace Cinema;

public class Film {
    private readonly List<Seat> _seats = new List<Seat>();

    public string Title { get; }
    public string Time { get; }

    public Film(string title, string time) {
        Title = title;
        Time = time;
        _seats.Add(new Seat(code: "A1"));
        _seats.Add(new Seat(code: "A2"));
        _seats.Add(new Seat(code: "B1"));
        _seats.Add(new Seat(code: "B2"));
    }

    public Seat Find(string code) {
        foreach (Seat seat in _seats) {
            if (seat.Code == code)
                return seat;
        }

        throw new InvalidOperationException("No seat " + code);
    }
    
    public void PrintSeats(){
        Console.WriteLine(Title + " " + Time);
        foreach (Seat seat in _seats){
            if (seat.IsFree)
                Console.WriteLine(" " + seat.Code + " free");
            else
                Console.WriteLine(" " + seat.Code + " taken");
        }
    }
}