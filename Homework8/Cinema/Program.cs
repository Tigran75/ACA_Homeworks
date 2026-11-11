namespace Cinema;

class Program {
    static void Main(string[] args) {
        Film dune = new Film(title: "Dune", time: "18:00");
        Film wonka = new Film(title: "Wonka", time: "20:00");
        Cinema cinema = new Cinema();
        cinema.Add(dune);
        cinema.Add(wonka);
        dune.PrintSeats();
        
        Sale sara = cinema.Sell(name: "Sara", dune, seatCode: "A1", kind: "adult", dayOfWeek: DayOfWeek.Wednesday);
        cinema.AddPopcorn(sara, count: 2);
        cinema.AddWater(sara, count: 1);
        sara.Print();
        cinema.Pay(sara);

        Console.WriteLine();
        
        Sale Alex = cinema.Sell(name: "Alex", dune, seatCode: "B1", kind: "child", dayOfWeek: DayOfWeek.Wednesday);
        cinema.AddPopcorn(Alex, count: 1);
        cinema.AddWater(Alex, count: 1);
        Alex.Print();
        cinema.Pay(Alex);

        Console.WriteLine();
        
        try {
            cinema.Sell(name: "Luka", dune, seatCode: "A1", kind: "adult", dayOfWeek: DayOfWeek.Wednesday);
        }
        catch (InvalidOperationException ex) {
            Console.WriteLine("A1 refused: " + ex.Message);
        }
        
        Sale luka = cinema.Sell(name: "Luka", dune, seatCode: "A2", kind: "child", dayOfWeek: DayOfWeek.Saturday);
        cinema.AddJuice(luka, count: 1);
        luka.Print();
        cinema.Pay(luka);

        Console.WriteLine();
        cinema.PrintFilms();
        cinema.PrintCash();
    }
}