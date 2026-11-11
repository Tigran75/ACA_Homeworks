namespace Cinema;

public class Cinema {
    private readonly List<Film> _films = new List<Film>();
    private int _popcornLeft;
    private int _waterLeft;
    private int _juiceLeft;
    private decimal _cash;

    public decimal PopcornPrice { get; }
    public decimal WaterPrice { get; }
    public decimal JuicePrice { get; }

    public Cinema()
    {
        PopcornPrice = 5.00m;
        WaterPrice = 2.00m;
        JuicePrice = 3.50m;

        _popcornLeft = 8;
        _waterLeft = 10;
        _juiceLeft = 10;
    }

    public void Add(Film film){
        _films.Add(film);
        Console.WriteLine("Added " + film.Title + " at " + film.Time);
    }
    
    public Sale Sell(string name, Film film, string seatCode, string kind, DayOfWeek dayOfWeek) {
        if (!_films.Contains(film))
            throw new InvalidOperationException(film.Title + " is not showing");

        Seat seat = film.Find(seatCode);
        seat.Take();
        decimal price = 10.00m;
        
        if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            price = 14.00m;
        
        if (kind == "child")
            price = price - 4.00m;

        Console.WriteLine(name + " took " + film.Title + " " + seat.Code + " (" + kind + ")");
        return new Sale(name, film, seat, kind, price);
    }
    
    public void AddPopcorn(Sale sale, int count) {
        if (count > _popcornLeft)
            throw new InvalidOperationException("Only " + _popcornLeft + " popcorn left");

        _popcornLeft = _popcornLeft - count;
        sale.AddPopcorn(count, PopcornPrice);
        Console.WriteLine("Added " + count + " popcorn");
    }

    public void AddWater(Sale sale, int count) {
        if (count > _waterLeft)
            throw new InvalidOperationException("Only " + _waterLeft + " water left");

        _waterLeft = _waterLeft - count;
        sale.AddWater(count, WaterPrice);
        Console.WriteLine("Added " + count + " water");
    }

    public void AddJuice(Sale sale, int count) {
        if (count > _juiceLeft)
            throw new InvalidOperationException("Only " + _juiceLeft + " juice left");

        _juiceLeft = _juiceLeft - count;
        sale.AddJuice(count, JuicePrice);
        Console.WriteLine("Added " + count + " juice");
    }

    public void Pay(Sale sale) {
        _cash = _cash + sale.Total;
        Console.WriteLine(sale.Name + " paid " + sale.Total.ToString(format: "0.00"));
    }

    public void PrintFilms() {
        foreach (Film film in _films)
            film.PrintSeats();
    }

    public void PrintCash() {
        Console.WriteLine("Cash " + _cash.ToString(format: "0.00"));
    }
}