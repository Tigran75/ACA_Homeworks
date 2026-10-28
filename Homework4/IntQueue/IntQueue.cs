namespace IntQueue;

public class IntQueue {
    private int[] arr = new int[4];
    public int Count { get; private set; }
    public void Enqueue(int value) {
        if (Count == arr.Length) {
            int[] newArr = new int[arr.Length * 2];
            for (int i = 0; i < Count; i++)
                newArr[i] = arr[i];
            arr = newArr;
        }
        arr[Count] = value;
        Count++;
    }

    public int? Dequeue() {
        if(Count == 0)
            return null;
        int val = arr[0];
        for(int i = 0; i < Count - 1; i++)
            arr[i] = arr[i + 1];
        Count--;
        return val;
    }
}