namespace IntList;

public class IntList {
    int[] arr = new int[4];
    public int Count { get; private set; } = 0;

    private void CheckIndex(int index) {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
    }

    private void Increase() {
        int[] newArr = new int[arr.Length * 2];
        for (int i = 0; i < Count; i++)
            newArr[i] = arr[i];
        arr = newArr;
    }

    public void Add(int num) {
        if (Count == arr.Length)
            Increase();

        arr[Count] = num;
        Count++;
    }

    public void Insert(int num, int index) {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (Count == arr.Length)
            Increase();

        for (int i = Count; i > index; i--)
            arr[i] = arr[i - 1];
        arr[index] = num;
        Count++;
    }

    public void RemoveAt(int index) {
        CheckIndex(index);

        for (int i = index; i < Count - 1; i++)
            arr[i] = arr[i + 1];
        arr[Count - 1] = 0;
        Count--;
    }

    public int Get(int index) {
        CheckIndex(index);
        return arr[index];
    }
}    