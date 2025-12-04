namespace AdventOfCode2025.Helpers;

public static class GridHelper
{
    public static char[,] GetGridFromTextInput(string[] input)
    {
        int rows = input.Length;
        int cols = input[0].Length;
        char[,] grid = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                grid[row, col] = input[row][col];
            }
        }

        return grid;
    }
}
