namespace IntStack;

public class IntStack {
    private int[] arr = new int[4];
    public int Count { get; private set; }

    public void Push(int value) {
        if (Count == arr.Length) {
            int[] newArr = new int[Count * 2];
            for (int i = 0; i < Count; i++)
                newArr[i] = arr[i];
            arr = newArr;
        }
        arr[Count] = value;
        Count++;
    }

    public void Pop() {
        if(Count == 0)
            return;
        int[] newArr = new int[Count - 1];
        for(int i = 0; i < Count - 1; i++)
            newArr[i] = arr[i];
        arr = newArr;
        Count--;
    }

    public void Peek() {
        if (Count == 0)
            return;
        Console.WriteLine(arr[Count - 1]);
    }
}