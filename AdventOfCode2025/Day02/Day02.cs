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
                if (IsInvalidIdPart1(id))
                    invalidIdSumPart1 += id;

                if (IsInvalidIdPart2(id))
                    invalidIdSumPart2 += id;
            }
        }

        Console.WriteLine("Day 2 Part 1: " + invalidIdSumPart1); //56660955519
        Console.WriteLine("Day 2 Part 2: " + invalidIdSumPart2); //79183223243
    }

    private static bool IsInvalidIdPart1(ulong id)
    {
        var idString = id.ToString();

        // Any uneven digit length is valid, since no sequence can be repeated
        if (idString.Length % 2 != 0)
            return false;

        var firstHalf = idString.Substring(0, idString.Length / 2);
        var secondHalf = idString.Substring(idString.Length / 2);

        if (firstHalf == secondHalf)
            return true;

        return false;
    }

    private static bool IsInvalidIdPart2(ulong id)
    {
        var idString = id.ToString();

        // Single digits are always valid
        if (idString.Length == 1)
            return false;

        // If all digits are the same, ID is invalid
        if (idString.Distinct().Count() == 1)
            return true;

        var idLength = idString.Length;
        var maxDenominatorToCheck = idLength / 2;

        for (var denominator = 2; denominator <= maxDenominatorToCheck; denominator++)
        {
            if (idLength % denominator != 0) continue;

            var firstSubstring = idString.Substring(0, denominator);
            var maxDenominatorSubstringsInId = idLength / denominator;
            var matches = 0;

            for (var substringStartAt = 0; substringStartAt < idLength; substringStartAt += denominator)
            {
                var substring = idString.Substring(substringStartAt, denominator);

                if (substring == firstSubstring)
                {
                    matches++;
                    if (matches == maxDenominatorSubstringsInId)
                        return true;
                    continue;
                }
                else
                    break;
            }

        }

        return false;
    }
}
