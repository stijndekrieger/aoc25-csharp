namespace AdventOfCode2025.Day02;

public class Day02
{
    public static void Run()
    {
        var idRanges = File.ReadAllLines("Day02/Data/Input.txt").First();

        var ranges = idRanges
            .Split(',')
            .Select(r => r.Split('-'))
            .Select(parts => (
                Start: ulong.Parse(parts[0]),
                End: ulong.Parse(parts[1])
            ));

        ulong invalidIdSumPart1 = 0;
        ulong invalidIdSumPart2 = 0;

        foreach (var (Start, End) in ranges)
        {
            for (var id = Start; id <= End; id++)
            {
                if (!IsValidIdPart1(id))
                {
                    invalidIdSumPart1 += id;
                }

                if (!IsValidIdPart2(id))
                {
                    invalidIdSumPart2 += id;
                }
            }
        }

        Console.WriteLine("Day 2 Part 1: " + invalidIdSumPart1); //56660955519
        Console.WriteLine("Day 2 Part 2: " + invalidIdSumPart2);
    }

    private static bool IsValidIdPart1(ulong id)
    {
        var idString = id.ToString();

        // Any uneven digit length is valid, since no sequence can be repeated
        if (idString.Length % 2 != 0)
            return true;

        var firstHalf = idString.Substring(0, idString.Length / 2);
        var secondHalf = idString.Substring(idString.Length / 2);

        if (firstHalf == secondHalf)
            return false;

        return true;
    }

    private static bool IsValidIdPart2(ulong id)
    {
        var idString = id.ToString();

        // TODO

        return true;
    }
}
