namespace AdventOfCode2025.Day03;

public class Day03
{
    public static void Run()
    {
        var batteryBanks = File.ReadAllLines("Day03/Data/Input.txt");

        ulong totalJoltagePart1 = 0;
        ulong totalJoltagePart2 = 0;

        foreach (var bank in batteryBanks)
        {
            totalJoltagePart1 += FindHighestJoltage(bank, 2);
            totalJoltagePart2 += FindHighestJoltage(bank, 12);
        }

        Console.WriteLine("Day 3 Part 1: " + totalJoltagePart1); //17109
        Console.WriteLine("Day 3 Part 2: " + totalJoltagePart2); //169347417057382
    }

    private static ulong FindHighestJoltage(string batteryBank, int amountOfDigits)
    {
        var bank = batteryBank.Select(n => n - '0').ToList();
        var joltageString = "";

        for (int i = amountOfDigits - 1; i >= 0; i--)
        {
            var highestValidNumber = FindNextHighestValidNumber(bank, i);
            joltageString += highestValidNumber.ToString();

            bank = bank.Skip(bank.IndexOf(highestValidNumber) + 1).ToList();
        }

        return ulong.Parse(joltageString);
    }

    private static int FindNextHighestValidNumber(List<int> bank, int digitsRemaining)
    {
        int index = 0;
        while (true)
        {
            var highestNumber = bank.OrderByDescending(n => n).Skip(index).First();
            var bankRightOfHighest = bank.Skip(bank.IndexOf(highestNumber) + 1).ToList();

            if (bankRightOfHighest.Count < digitsRemaining)
            {
                index++;
                continue;
            }
            else
                return highestNumber;
        }
    }
}
