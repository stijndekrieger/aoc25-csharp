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
        var currentRow = 1;
        var beamColumns = new List<(int column, ulong count)> { (startingColumn, 1) };
        while (true)
        {
            if (currentRow >= diagram.GetLength(0))
                break;

            var newBeamColumns = new List<(int column, ulong count)>();
            foreach (var (column, count) in beamColumns)
            {
                if (diagram[currentRow, column] == '.')
                {
                    newBeamColumns.Add((column, count));
                    continue;
                }
                else if (diagram[currentRow, column] == '^')
                {

                    newBeamColumns.Add((column - 1, count));
                    newBeamColumns.Add((column + 1, count));

                    amountOfSplits++;
                }
            }

            beamColumns = newBeamColumns
                .GroupBy(t => t.column)
                .Select(g => (g.Key, (ulong)g.Sum(t => (long)t.count)))
                .ToList();

            currentRow++;
        }

        var amountOfTimelines = (ulong)beamColumns.Sum(bc => (long)bc.count);

        Console.WriteLine("Day 7 Part 1: " + amountOfSplits);
        Console.WriteLine("Day 7 Part 2: " + amountOfTimelines);
    }
}
