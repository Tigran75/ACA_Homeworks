namespace IntQueue;

class Program {
    static void Main(string[] args) {
        IntQueue queue = new IntQueue();
        
         queue.Enqueue(1);
         queue.Enqueue(2);
         queue.Enqueue(3);
         queue.Enqueue(4);
         queue.Enqueue(5);
        
         queue.Dequeue();
         queue.Dequeue();
         queue.Dequeue();
         queue.Dequeue();
         queue.Dequeue();
    }
}