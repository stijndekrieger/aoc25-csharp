namespace AdventOfCode2025.Day03;

public class Day03
{
    public static void Run()
    {
        var banks = File.ReadAllLines("Day03/Data/Input.txt");
        var totalJoltage = 0;

        foreach (var bank in banks)
        {
            var highestJoltage = FindHighestJoltageInBank(bank);
            totalJoltage += highestJoltage;
        }

        Console.WriteLine("Day 3 Part 1: " + totalJoltage);
        Console.WriteLine("Day 3 Part 2: " + 0);
    }

    private static int FindHighestJoltageInBank(string stringBank)
    {
        var bank = stringBank.Select(n => n - '0').ToList();

        int index = 0;
        while (true)
        {
            var highestNumber = bank.OrderByDescending(n => n).Skip(index).First();
            var bankRightOfHighest = bank.Skip(bank.IndexOf(highestNumber) + 1).ToList();

            if (bankRightOfHighest.Count == 0)
            {
                index++;
                continue;
            }
            else
            {
                var nextHighest = bankRightOfHighest.Max();
                return int.Parse(highestNumber.ToString() + nextHighest.ToString());
            }
        }
    }
}
