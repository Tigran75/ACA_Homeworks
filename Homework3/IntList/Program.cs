namespace IntList;

class Program {
    static void Print(IntList list) {
        Console.Write("[");
        for (int i = 0; i < list.Count; i++) {
            Console.Write(list.Get(i));
            if (i < list.Count - 1)
                Console.Write(", ");
        }
        Console.Write("]");
        Console.WriteLine(" Count = " + list.Count);
    }
    static void Main(string[] args) {

        IntList list = new IntList();
        list.Add(4);
        Print(list);
        list.Add(8);
        Print(list);
        list.Add(15);
        Print(list);
        Console.WriteLine("Element at index 0: " + list.Get(0));
        Console.WriteLine("Element at index 2: " + list.Get(2));
        list.Insert(6, 1);
        Print(list);
        Console.WriteLine("Element at index 1: " + list.Get(1));
        list.Insert(1, 0);
        Print(list);
        list.Insert(9, 5);
        Print(list);
        list.RemoveAt(2);
        Print(list);
        Console.WriteLine("Element at index 2: " + list.Get(2));
        list.RemoveAt(0);
        Print(list);
        list.RemoveAt((list.Count)-1);
        Print(list);
        Console.WriteLine("Element at index 0: " + list.Get(0));
        Console.WriteLine("Element at index 2: " + list.Get(2));
        
    }
}