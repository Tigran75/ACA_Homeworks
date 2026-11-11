namespace Cinema;

public class Sale {
    public Film Film { get; }
    public Seat Seat { get; }
    public string Name { get; }
    public string Kind { get; }
    public decimal TicketPrice { get; }
    
    public int Popcorn { get; private set; }
    public decimal PopcornTotal { get; private set; }

    public int Water { get; private set; }
    public decimal WaterTotal { get; private set; }

    public int Juice { get; private set; }
    public decimal JuiceTotal { get; private set; }

    public Sale(string name, Film film, Seat seat, string kind, decimal ticketPrice) {
        Name = name;
        Film = film;
        Seat = seat;
        Kind = kind;
        TicketPrice = ticketPrice;
    }

    public decimal Total {
        get { return TicketPrice + PopcornTotal + WaterTotal + JuiceTotal; }
    }

    public void AddPopcorn(int count, decimal priceEach) {
        Popcorn = Popcorn + count;
        PopcornTotal = PopcornTotal + (priceEach * count);
    }

    public void AddWater(int count, decimal priceEach) {
        Water = Water + count;
        WaterTotal = WaterTotal + (priceEach * count);
    }

    public void AddJuice(int count, decimal priceEach){
        Juice = Juice + count;
        JuiceTotal = JuiceTotal + (priceEach * count);
    }

    public void Print() {
        Console.WriteLine(Name + " " + Kind + " " + Seat.Code + " " + TicketPrice.ToString(format: "0.00"));
        
        if (Popcorn > 0)
            Console.WriteLine(" Popcorn x " + Popcorn + " " + PopcornTotal.ToString(format: "0.00"));
        if (Water > 0)
            Console.WriteLine(" Water x " + Water + " " + WaterTotal.ToString(format: "0.00"));
        if (Juice > 0)
            Console.WriteLine(" Juice x " + Juice + " " + JuiceTotal.ToString(format: "0.00"));
    }
}