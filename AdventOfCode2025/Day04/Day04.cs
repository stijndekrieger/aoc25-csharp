using AdventOfCode2025.Extensions;
using AdventOfCode2025.Helpers;

namespace AdventOfCode2025.Day04;

public class Day04
{
    private static readonly char[,] Grid = GridHelper.GetGridFromTextInput(File.ReadAllLines("Day04/Data/Input.txt"));

    public static void Run()
    {
        // Part 1
        (_, int amountAccessible) = MarkAllAccessibleRolls(Grid);

        // Part 2
        var gridCopy = (char[,])Grid.Clone();
        var totalRemoved = 0;

        while (true)
        {
            (var markedGrid, int amountMarked) = MarkAllAccessibleRolls(gridCopy);
            markedGrid.ReplaceAll('x', '.');
            gridCopy = markedGrid;
            totalRemoved += amountMarked;

            if (amountMarked == 0)
                break;
        }

        Console.WriteLine("Day 4 Part 1: " + amountAccessible); //1384
        Console.WriteLine("Day 4 Part 2: " + totalRemoved); //8013
    }

    private static bool IsCellAccessibleInGrid(char[,] grid, int cellRow, int cellCol)
    {
        int adjacentPaperCount = 0;
        int[] offsets = [-1, 0, 1];

        foreach (int rowDiff in offsets)
        {
            foreach (int colDiff in offsets)
            {
                if (rowDiff == 0 && colDiff == 0)
                    continue;

                int newRow = cellRow + rowDiff;
                int newCol = cellCol + colDiff;

                if (newRow < 0 || newRow >= grid.GetLength(0)) continue;
                if (newCol < 0 || newCol >= grid.GetLength(1)) continue;

                if (grid[newRow, newCol] == '@')
                {
                    adjacentPaperCount++;
                    if (adjacentPaperCount > 3)
                        return false;
                }
            }
        }

        return true;
    }

    private static (char[,], int) MarkAllAccessibleRolls(char[,] grid)
    {
        var newGrid = (char[,])grid.Clone();
        var rollsMarked = 0;

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[row, col] == '.')
                    continue;
                else
                {
                    if (IsCellAccessibleInGrid(grid, row, col))
                    {
                        newGrid[row, col] = 'x';
                        rollsMarked++;
                    }
                }
            }
        }

        return (newGrid, rollsMarked);
    }
}
