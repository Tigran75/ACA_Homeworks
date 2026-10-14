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

    static bool TryReadPlayer(out Cell player1, out Cell player2) {
        player1 = Cell.Empty;
        player2 = Cell.Empty;
        Console.Write("Which one are you? (X or O | 1 or 2): ");
        string input = Console.ReadLine()!;
        if (int.TryParse(input, out int number)) {
            if (number == 1 || number == 2)
                player1 = (Cell)number;
            else {
                Console.WriteLine("Wrong input");
                return false;
            }
        }
        else {
            if (input.ToLower() == "x")
                player1 = Cell.X;
            else if (input.ToLower() == "o")
                player1 = Cell.O;
            else {
                Console.WriteLine("Wrong input");
                return false;
            }
        }
        if (player1 == Cell.X)
            player2 = Cell.O;
        else
            player2 = Cell.X;
        return true;
    }

    static Move ReadMove(Cell[,] board,Cell currentPlayer) {
        while (true) {
            Console.WriteLine($"{currentPlayer}'s turn: ");
            int row = ReadNumber("Row");
            int col = ReadNumber("Column");
            if (row > 0 && row <= 3 && col > 0 && col <= 3 && board[row - 1, col - 1] == Cell.Empty)
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
            if (line != null && int.TryParse(line, out number))
                return number;
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

    static bool IsBoardFull(Cell[,] board) {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i, j] == Cell.Empty)
                    return false;
            }
        }

        return true;
    }

    static char Mark(Cell cell) {
        if (cell == Cell.X)
            return 'X';
        if (cell == Cell.O)
            return 'O';
        return '.';
    }

    static void Game(Cell[,] board, Cell player1, Cell player2) {
        Cell currentPlayer;
        if (player1 == Cell.X)
            currentPlayer = player1;
        else
            currentPlayer = player2;
        Console.WriteLine();
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

            if (currentPlayer == player1)
                currentPlayer = player2;
            else
                currentPlayer = player1;
        }

    }

    static void Main(string[] args) {

        Cell[,] board = new Cell[3, 3];
        Console.WriteLine("Welcome to TicTacToe!");
        TryReadPlayer(out Cell player1, out Cell player2);
        Game(board, player1, player2);
        
    }
}