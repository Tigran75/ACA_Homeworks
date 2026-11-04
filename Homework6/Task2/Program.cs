namespace Task2;

class Program
{
    delegate int Mix(int n);

    static Mix[] Build() {
        Bonus bonus = new Bonus();
        Mix[] rows = new Mix[3];

        for (int i = 0; i < 3; i++) {
            Row row = new Row(i, bonus);
            rows[i] = row.Calculate;
        }
        bonus.bonus = 50;
        
        return rows;
    }

    static void Main() {
        Mix[] rows = Build();

        Console.WriteLine(rows[0](2));
        Console.WriteLine(rows[1](2));
        Console.WriteLine(rows[2](2));
        Console.WriteLine(rows[0](0));
    }
}