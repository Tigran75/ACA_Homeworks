namespace Task2;

class Program
{
    static void Main(string[] args) {

        Attempt[][] jagged = {
            new Attempt[] { new Attempt(40, 1), new Attempt(20, 2),
                new Attempt(90, 3)},
            new Attempt[] { new Attempt(60, 1), new Attempt(45, 2) },
            new Attempt[] { new Attempt(80, 1), new Attempt(95, 2),
                new Attempt(70, 3), new Attempt(75, 4) },
            new Attempt[] { new Attempt(70, 1), new Attempt(50, 2),
                new Attempt(70, 3), new Attempt(65, 4) }
        };
        
        Attempt[] jaggedBest = BestAttempt(jagged);
        for(int i = 0; i < jaggedBest.Length; i++)
            Console.Write($"(Score: {jaggedBest[i].Score}, Day: {jaggedBest[i].Day}) ");
    }
 

    static Attempt[] BestAttempt(Attempt[][] jagged) {
        Attempt[] result = new Attempt[jagged.Length];
        
        for (int i = 0; i < jagged.Length; i++) {
            Attempt best = jagged[i][0];
            for(int j = 1; j < jagged[i].Length; j++)
                if(jagged[i][j].Score > best.Score)
                    best = jagged[i][j];
            result[i] = best;
        }

        return result;
    }
}

struct Attempt {
    public int Score;
    public int Day;
    
    public Attempt(int score, int day) {
        Score = score;
        Day = day;
    }
}       