namespace AdventOfCode2025.Day06;

public class Day06
{
    public static void Run()
    {
        var input = File.ReadAllLines("Day06/Data/Input.txt");

        var rows = new List<List<string>>();

        foreach (var line in input)
        {
            var row = line.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList();
            rows.Add(row);
        }

        ulong resultTotal = 0;

        var length = rows[0].Count;
        for (int i = 0; i < length; i++)
        {
            var problem = rows.Select(r => r[i]).ToList();
            var problemOperator = problem.Last();
            ulong problemResult = 0;

            switch (problemOperator)
            {
                case "+":
                    foreach (var digit in problem.Take(problem.Count - 1))
                    {
                        problemResult += ulong.Parse(digit);
                    }
                    break;
                case "*":
                    problemResult = 1;
                    foreach (var digit in problem.Take(problem.Count - 1))
                    {
                        problemResult *= ulong.Parse(digit);
                    }
                    break;
            }

            resultTotal += problemResult;
        }

        Console.WriteLine("Day 6 Part 1: " + resultTotal);
        Console.WriteLine("Day 6 Part 2: -");
    }
}
