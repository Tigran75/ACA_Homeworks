namespace Task3;

class Program
{
    static void Main(string[] args) {
        int n = 2;
        int m = 3;
        int limit = 6;
        
        Reading[,] matrix = new Reading[n, m];
        matrix[0, 0] = new Reading(8, true);
        matrix[0, 1] = new Reading(3, false);
        matrix[0, 2] = new Reading(5, true);
        matrix[1, 0] = new Reading(1, false);
        matrix[1, 1] = new Reading(7, false);
        matrix[1, 2] = new Reading(6, true);
        
        Hit[] matrixResult = ColderThan(matrix, limit);
        for (int i = 0; i < matrixResult.Length; i++) {
            Console.WriteLine($"(Temperature: {matrixResult[i].Temperature}, " + 
                $"Row: {matrixResult[i].Row}, Col: {matrixResult[i].Col})");
        }
    }

    static Hit[] ColderThan(Reading[,] matrix, int limit) {
        Hit[] result = new Hit[matrix.GetLength(0)*matrix.GetLength(1)];
        int index = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j].Temperature < limit && matrix[i, j].Fault == false) {
                    result[index] = new Hit(matrix[i, j].Temperature, i, j);
                    index++;
                }
            }
        }
        
        Array.Resize(ref result, index);
        return result;
    }
}

struct Reading {
    public int Temperature;
    public bool Fault;

    public Reading(int temperature, bool fault) {
        Temperature = temperature;
        Fault = fault;
    }
}

struct Hit {
    public int Temperature;
    public int Row;
    public int Col;
    
    public Hit(int temperature, int row, int col) {
        Temperature = temperature;
        Row = row;
        Col = col;
    }
}