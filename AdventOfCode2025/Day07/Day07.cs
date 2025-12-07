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
        var currentRow = 0;
        var beamColumns = new List<int> { startingColumn };
        var debugDiagram = (char[,])diagram.Clone();
        while (true)
        {
            if (currentRow >= diagram.GetLength(0))
                break;

            var columnsToRemove = new List<int>();
            var columnsToAdd = new List<int>();
            foreach (var column in beamColumns)
            {
                if (diagram[currentRow, column] == '.')
                {
                    debugDiagram[currentRow, column] = '|';
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
                beamColumns.Remove(col);

            beamColumns.AddRange(columnsToAdd);
            beamColumns = beamColumns.Distinct().ToList();

            //debugDiagram.PrintToConsole();
            currentRow++;
        }


        Console.WriteLine("Day 7 Part 1: " + amountOfSplits);
        Console.WriteLine("Day 7 Part 2: " + 0);
    }
}
