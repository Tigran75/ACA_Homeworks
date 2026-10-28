namespace Tasks;

class Program {
    public delegate int Op(int n);

    static int Double(int n) {
        return n * 2;
    }

    static int PlusTen(int n) {
        return n + 10;
    }

    static int Apply(int num, Op op) {
        return op(num);
    }

    static int Pick(int num) {
        Op op;
        if (num % 2 == 0) {
            op = Double;
            return op(num);
        }
        op = PlusTen;
        return op(num);
    }
    
    static void Main(string[] args) {
        //Task 1
        Console.WriteLine("Task 1:");
        Op op = Double;
        Console.WriteLine("Double(4) = " + op(4));
        Console.WriteLine("Double(7) = " + op(7));
        op =  PlusTen;
        Console.WriteLine("PlusTen(4) = " + op(4));
        Console.WriteLine("PlusTen(7) = " + op(7));
        
        //Task 2
        Console.WriteLine("\nTask 2:");
        op = Double;
        Console.WriteLine("Apply(5, Double) = " + Apply(5, op));        
        Console.WriteLine("Apply(0, Double) = " + Apply(0, op));        
        op = PlusTen;
        Console.WriteLine("Apply(5, PlusTen) = " + Apply(5, op));
        Console.WriteLine("Apply(0, PlusTen) = " + Apply(0, op));
        
        //Task3
        Console.WriteLine("\nTask 3");
        Console.WriteLine("Pick(4) = " + Pick(4));
        Console.WriteLine("Pick(5) = " + Pick(5));
        Console.WriteLine("Pick(0) = " + Pick(0));
        Console.WriteLine("Pick(7) = " + Pick(7));
    }
}