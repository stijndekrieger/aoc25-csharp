namespace AdventOfCode2025.Day01;

public class Day01
{
    public static void Run()
    {
        var rotations = File.ReadAllLines("Day01/Data/Input.txt");
        var dialPosition = 50;

        // Part 1
        var pointingAtZeroCount = 0;

        // Part 2
        var clickingPastZeroCount = 0;

        foreach (var rotation in rotations)
        {
            var direction = rotation[0];
            var rawAmount = int.Parse(rotation[1..]);

            // Only the two last digits are relevant for rotation. Example: R6116, R616 and R16 all have the same ending position of the dial
            var amount = rawAmount % 100;

            // For part 2, the first digits are only relevant for clicking past 0
            clickingPastZeroCount += rawAmount / 100;

            var dialStartedAtZero = dialPosition == 0;

            if (direction == 'L')
            {
                dialPosition -= amount;

                if (dialPosition < 0)
                {
                    if (!dialStartedAtZero)
                        clickingPastZeroCount++;

                    dialPosition += 100;
                }

            }
            else if (direction == 'R')
            {
                dialPosition += amount;

                if (dialPosition >= 100)
                {
                    if (!dialStartedAtZero && dialPosition != 100)
                        clickingPastZeroCount++;

                    dialPosition -= 100;
                }

            }

            if (dialPosition == 0)
                pointingAtZeroCount++;
        }

        Console.WriteLine("Day 1 Part 1: " + pointingAtZeroCount); //1129
        Console.WriteLine("Day 1 Part 2: " + (pointingAtZeroCount + clickingPastZeroCount)); //6638
    }
}
