namespace IntStack;

class Program {
    static void Main(string[] args) {
        IntStack stack = new IntStack();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Peek();
        stack.Push(4);
        stack.Push(5);

        stack.Pop();
        stack.Peek();
        stack.Pop();
        stack.Pop();
        stack.Pop();
        stack.Pop();
    }
}