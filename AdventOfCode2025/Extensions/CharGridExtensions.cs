namespace AdventOfCode2025.Extensions;

public static class CharGridExtensions
{
    public static void ReplaceAll(this char[,] grid, char from, char to)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] == from)
                    grid[row, col] = to;
            }
        }
    }

    public static void PrintToConsole(this char[,] grid)
    {
        Console.WriteLine();
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Console.Write(grid[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
