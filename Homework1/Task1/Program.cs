namespace Task1;

class Program
{
    static void Main(string[] args) {
        
        Console.Write("Enter the number of rows in the matrix: ");
        int.TryParse(Console.ReadLine(), out int n); 
        
        Console.Write("Enter the number of columns in the matrix: ");
        int.TryParse(Console.ReadLine(), out int m);
        
        int[,] matrix = new int[n, m];
        
        Console.WriteLine("Enter the elements of the matrix: ");
        for (int i = 0; i < n; i++) {
            string[] row = Console.ReadLine()!.Split();
            for (int j = 0; j < m; j++)
                int.TryParse(row[j], out matrix[i,j]);
        }
        
        Console.Write("Enter the limit: ");
        int.TryParse(Console.ReadLine(), out int limit);
        
        int[] arrAbove = Above(matrix, limit);
        
        Console.Write($"Here are the elements of the matrix greater than the limit: ");
        for(int i = 0; i < arrAbove.Length; i++)
            Console.Write(arrAbove[i] + " ");
    }

    static int[] Above(int[,] matrix, int limit) {
        int[] result = new int[matrix.Length];
        int index = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] > limit) {
                    result[index] = matrix[i, j];
                    index++;
                }
            }
        }
        
        Array.Resize(ref result, index);
        return result;
    }
}