namespace AdventOfCode2025.Day05;

public class Day05
{
    private record Range(long Min, long Max);

    public static void Run()
    {
        var input = File.ReadAllLines("Day05/Data/Input.txt");

        var freshIngredientIdRanges = input
            .Where(l => l.Contains('-'))
            .Select(l =>
            {
                var parts = l.Split('-');
                return (Start: ulong.Parse(parts[0]), End: ulong.Parse(parts[1]));
            })
            .ToArray();

        var availableIngredientIds = input
            .Where(l => l.Length > 0 && !l.Contains('-'))
            .Select(ulong.Parse)
            .ToArray();

        var amountOfFreshIngredients = 0;
        foreach (var ingredientId in availableIngredientIds)
        {
            foreach ((ulong start, ulong end) in freshIngredientIdRanges)
            {
                if (ingredientId >= start && ingredientId <= end)
                {
                    amountOfFreshIngredients++;
                    break;
                }
            }
        }

        var ranges = input
            .Where(l => l.Contains('-'))
            .Select(l =>
            {
                var parts = l.Split('-');
                return new Range(long.Parse(parts[0]), long.Parse(parts[1]));
            })
            .ToArray();

        HashSet<Range> finalRanges = [];
        foreach (var range in ranges)
        {
            List<Range> toRemove = [];
            Range toAdd = range;
            foreach (var existing in finalRanges)
            {
                if (toAdd.Min <= existing.Max && toAdd.Max >= existing.Min)
                {
                    toRemove.Add(existing);
                    var newMin = Math.Min(toAdd.Min, existing.Min);
                    var newMax = Math.Max(toAdd.Max, existing.Max);
                    toAdd = new Range(newMin, newMax);
                }
            }
            finalRanges.ExceptWith(toRemove);
            finalRanges.Add(toAdd);
        }
        var answer = finalRanges.Sum(r => r.Max - r.Min + 1);

        Console.WriteLine("Day 5 Part 1: " + amountOfFreshIngredients); //643
        Console.WriteLine("Day 5 Part 2: " + answer);
    }
}
