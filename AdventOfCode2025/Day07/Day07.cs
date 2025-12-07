using AdventOfCode2025.Helpers;

namespace AdventOfCode2025.Day07;

public class Day07
{
    public static void Run()
    {
        var diagram = GridHelper.GetGridFromTextInput(File.ReadAllLines("Day07/Data/input.txt"));

        var startingColumn = 0;

        for (int col = 0; col < diagram.GetLength(1); col++)
        {
            if (diagram[0, col] == 'S')
            {
                startingColumn = col;
                break;
            }
        }

        var amountOfSplits = 0;
        // TODO
        var amountOfTimelines = 0;
        var currentRow = 0;
        var beamColumns = new List<(int, int)> { (startingColumn, 1) };
        while (true)
        {
            if (currentRow >= diagram.GetLength(0))
                break;

            if (currentRow > 100)
            {
                var x = beamColumns.OrderBy(bc => bc.Item1).ToList();
            }

            var columnsToRemove = new List<int>();
            var columnsToAdd = new List<int>();
            foreach (var (column, amount) in beamColumns)
            {
                if (diagram[currentRow, column] == '.')
                {
                    continue;
                }
                else if (diagram[currentRow, column] == '^')
                {
                    columnsToRemove.Add(column);
                    columnsToAdd.AddRange(column + 1, column - 1);
                    amountOfSplits++;
                }
            }

            foreach (var col in columnsToRemove)
            {
                var column = beamColumns.First(bc => bc.Item1 == col);
                var newValue = column.Item2 - 1;
                if (newValue <= 0)
                {
                    beamColumns.Remove(column);
                }
                else
                {
                    column.Item2--;
                }
            }

            foreach (var col in columnsToAdd)
            {
                var column = beamColumns.FirstOrDefault(bc => bc.Item1 == col);
                if (column != default)
                {
                    column.Item2++;
                }
                else
                {
                    beamColumns.Add((col, 1));
                }
            }

            currentRow++;
        }

        Console.WriteLine("Day 7 Part 1: " + amountOfSplits);
        Console.WriteLine("Day 7 Part 2: " + amountOfTimelines);
    }
}
