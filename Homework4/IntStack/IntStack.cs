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

    public int? Pop() {
        if(Count == 0)
            return null;
        int val = arr[Count - 1];
        Count--;
        return val;
    }

    public int? Peek() {
        if (Count == 0)
            return null;
        return arr[Count - 1];
    }
}