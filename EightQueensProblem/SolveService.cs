namespace EightQueensProblem
{
    public class SolveService
    {
        private readonly int boardSize;

        private readonly int[] queenPositions;
        private readonly bool[] occupiedColumns;
        private readonly bool[] occupiedMainDiagonals;
        private readonly bool[] occupiedSecondaryDiagonals;

        private int solutionsCount = 0;

        private long attemptsCount = 0;

        private readonly bool printSolutions;

        public SolveService(int boardSize, bool printSolutions)
        {
            if (boardSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(boardSize));
            }

            this.boardSize = boardSize;

            this.queenPositions = new int[boardSize];
            this.occupiedColumns = new bool[boardSize];
            this.occupiedMainDiagonals = new bool[(2 * boardSize) - 1];
            this.occupiedSecondaryDiagonals = new bool[(2 * boardSize) - 1];

            this.printSolutions = printSolutions;
        }

        public int SolutionsCount => this.solutionsCount;

        public long AttemptsCount => this.attemptsCount;

        public void PlaceQueen(int row)
        {
            for (int col = 0; col < boardSize; col++)
            {
                this.attemptsCount++;

                if (!this.IsPositionAvailable(row, col))
                {
                    continue;
                }

                this.queenPositions[row] = col;
                this.SetQueenAttacks(row, col, true);

                if (row == boardSize - 1)
                {
                    this.PrintSolution();
                }
                else
                {
                    this.PlaceQueen(row + 1);
                }

                this.SetQueenAttacks(row, col, false);
            }
        }

        private bool IsPositionAvailable(int row, int col) =>
            !this.occupiedColumns[col] &&
            !this.occupiedMainDiagonals[row - col + (boardSize - 1)] &&
            !this.occupiedSecondaryDiagonals[row + col];

        private void SetQueenAttacks(int row, int col, bool occupied)
        {
            this.occupiedColumns[col] = occupied;
            this.occupiedMainDiagonals[row - col + (boardSize - 1)] = occupied;
            this.occupiedSecondaryDiagonals[row + col] = occupied;
        }

        public void PrintSolution()
        {
            solutionsCount++;

            if (!this.printSolutions)
            {
                return;
            }

            Console.WriteLine($"Solution #{solutionsCount}");

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(queenPositions[i] == j ? "Q" : ".");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}