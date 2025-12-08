namespace AdventOfCode2025.Day08;

public class Day08
{
    private record CircuitBox(int Id, int X, int Y, int Z);

    public static void Run()
    {
        var circuitBoxId = 1;
        var circuitBoxes = File.ReadAllLines("Day08/Data/Input.txt")
            .Select(line =>
            {
                var parts = line.Split(',');
                return new CircuitBox(
                    circuitBoxId++,
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    int.Parse(parts[2])
                );
            })
            .ToList();

        var circuits = new List<List<CircuitBox>>();
        for (int i = 0; i < 10; i++)
        {
            var (mainBox, secondaryBox) = GetClosestBoxes(circuitBoxes, circuits);

            var existingCircuit = circuits.FirstOrDefault(c => c.Any(b => b.Id == mainBox.Id || b.Id == secondaryBox.Id));
            if (existingCircuit is not null)
            {
                if (!existingCircuit.Any(b => b.Id == mainBox.Id))
                    existingCircuit.Add(mainBox);
                else if (!existingCircuit.Any(b => b.Id == secondaryBox.Id))
                    existingCircuit.Add(secondaryBox);
            }
            else
            {
                var newCircuit = new List<CircuitBox> { mainBox, secondaryBox };
                circuits.Add(newCircuit);
            }
        }

        // Answer correct but not circuits
        var part1Answer = circuits.OrderByDescending(c => c.Count).Take(3).Select(c => c.Count).Aggregate(1, (x, y) => x * y);

        Console.WriteLine("Day 8 Part 1: {0}", part1Answer);
        Console.WriteLine("Day 8 Part 2: {0}", 0);
    }

    private static (CircuitBox, CircuitBox) GetClosestBoxes(List<CircuitBox> circuitBoxes, List<List<CircuitBox>> circuits)
    {
        var shortestDistance = double.MaxValue;
        CircuitBox? shortestDistanceMainBox = null;
        CircuitBox? shortestDistanceSecondaryBox = null;
        foreach (var mainBox in circuitBoxes)
        {
            foreach (var secondaryBox in circuitBoxes)
            {
                if (mainBox == secondaryBox)
                    continue;

                if (circuits.Any(c => c.Any(b => b.Id == mainBox.Id) && c.Any(b => b.Id == secondaryBox.Id)))
                    continue;

                var distance = GetDistanceBetweenBoxes(mainBox, secondaryBox);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    shortestDistanceMainBox = mainBox;
                    shortestDistanceSecondaryBox = secondaryBox;
                }
            }
        }

        return (shortestDistanceMainBox!, shortestDistanceSecondaryBox!);
    }

    private static double GetDistanceBetweenBoxes(CircuitBox mainBox, CircuitBox secondaryBox)
    {
        return Math.Sqrt(Math.Pow(secondaryBox.X - mainBox.X, 2) + Math.Pow(secondaryBox.Y - mainBox.Y, 2) + Math.Pow(secondaryBox.Z - mainBox.Z, 2));
    }
}
