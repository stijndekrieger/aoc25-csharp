namespace AdventOfCode2025.Day08;

public class Day08
{
    private record CircuitBox(int X, int Y, int Z);

    public static void Run()
    {
        var circuitBoxes = File.ReadAllLines("Day08/Data/Input.txt")
            .Select(line =>
            {
                var parts = line.Split(',');
                return new CircuitBox(
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    int.Parse(parts[2])
                );
            })
            .ToList();

        var shortestDistance = double.MaxValue;
        CircuitBox shortestDistanceMainBox;
        CircuitBox shortestDistanceSecondaryBox;
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Iteration {0}", i);
            foreach (var mainBox in circuitBoxes)
            {
                foreach (var secondaryBox in circuitBoxes)
                {
                    var distance = GetDistanceBetweenBoxes(mainBox, secondaryBox);

                    if (distance != 0 && distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        shortestDistanceMainBox = mainBox;
                        shortestDistanceSecondaryBox = secondaryBox;
                    }
                }
            }
        }

        Console.WriteLine("Day 8 Part 1: {0}", 0);
        Console.WriteLine("Day 8 Part 2: {0}", 0);
    }

    private static double GetDistanceBetweenBoxes(CircuitBox mainBox, CircuitBox secondaryBox)
    {
        return Math.Sqrt(Math.Pow(secondaryBox.X - mainBox.X, 2) + Math.Pow(secondaryBox.Y - mainBox.Y, 2) + Math.Pow(secondaryBox.Z - mainBox.Z, 2));
    }
}
