namespace Task1;

class Program {
    enum Cell {
        Empty = 0,
        X,
        O
    }

    struct Move {
        public int Row;
        public int Col;

        public Move(int row, int col) {
            Row = row;
            Col = col;
        }
    }

    static Move ReadMove(Cell[,] board,Cell currentPlayer) {
        while (true) {
            Console.WriteLine($"{currentPlayer}'s turn: ");
            int row = ReadNumber("Row");
            int col = ReadNumber("Column");
            if (board[row - 1, col - 1] == Cell.Empty)
                return new Move(row - 1, col - 1);
            Console.WriteLine();
            PrintBoard(board);
            Console.WriteLine("Pick an empty cell");
            
        }
    }

    static int ReadNumber(string name) {
        while (true) {
            Console.Write($"{name}: ");
            string line = Console.ReadLine();
            int number;
            if (line != null && int.TryParse(line, out number)) {
                if(number > 0 && number <= 3)
                    return number;
                Console.WriteLine("Enter a number between 1 and 3");
            }
            else
                Console.WriteLine("Enter a whole number");
        }
    }

    static bool Line(Cell a, Cell b, Cell c) {
        if (a != Cell.Empty && a == b && b == c)
            return true;
        return false;
    }

    static Cell Winner(Cell[,] board) {
        for (int i = 0; i < 3; i++) {
            if (Line(board[i, 0], board[i, 1], board[i, 2]))
                return board[i, 0];
            if (Line(board[0, i], board[1, i], board[2, i]))
                return board[0, i];
        }

        if (Line(board[0, 0], board[1, 1], board[2, 2]))
            return board[0, 0];
        if (Line(board[0, 2], board[1, 1], board[2, 0]))
            return board[0, 2];
        return Cell.Empty;
    }

    static void PrintBoard(Cell[,] board) {
        Console.WriteLine("  1 2 3");
        for (int row = 0; row < 3; row++) {
            Console.Write($"{row + 1} ");
            for (int col = 0; col < 3; col++) {
                Console.Write($"{Mark(board[row, col])} ");
            }

            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    static char Mark(Cell cell) {
        if (cell == Cell.X)
            return 'X';
        if (cell == Cell.O)
            return 'O';
        return '.';
    }

    static bool IsBoardFull(Cell[,] board) {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i, j] == Cell.Empty)
                    return false;
            }
        }

        return true;
    }

    static void Game(Cell[,] board) {
        Console.WriteLine("Welcome to TicTacToe!\n");
            
        Cell currentPlayer = Cell.X;

        while (true) {
            PrintBoard(board);
            Move move = ReadMove(board, currentPlayer);
            Console.WriteLine();
            board[move.Row, move.Col] = currentPlayer;
            
            if(Winner(board) != Cell.Empty){
                PrintBoard(board);
                Console.WriteLine($"Winner: {Winner(board)}!");
                break;
            }

            if (IsBoardFull(board)) {
                PrintBoard(board);
                Console.WriteLine($"It's a draw!");
                break;
            }

            if (currentPlayer == Cell.X)
                currentPlayer = Cell.O;
            else
                currentPlayer = Cell.X;
        }
    }

    static void Main(string[] args) {

        Cell[,] board = new Cell[3, 3];
        Game(board);
        
    }
}