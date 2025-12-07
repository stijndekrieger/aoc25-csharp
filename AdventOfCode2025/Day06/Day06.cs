namespace AdventOfCode2025.Day06;

public class Day06
{
    public static void Run()
    {
        var input = File.ReadAllLines("Day06/Data/Input.txt");
        var rows = new List<List<string>>();

        // Part 1
        ulong resultTotalPart1 = 0;

        foreach (var line in input)
        {
            var row = line.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList();
            rows.Add(row);
        }

        for (int i = 0; i < rows[0].Count; i++)
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

            resultTotalPart1 += problemResult;
        }

        // Part 2
        ulong resultTotalPart2 = 0;
        for (int i = 0; i < rows[0].Count; i++)
        {
            int columnDigitLength = input
                .Where(l => l.Trim().Length > 0)
                .Select(l => l.TakeWhile(c => c != ' ').Count())
                .Max();

            var column = input
                .Select(l => l.PadRight(columnDigitLength).Substring(0, columnDigitLength))
                .ToList();

            var problemOperator = column.Last();
            column.Remove(problemOperator);
            problemOperator = problemOperator.Trim();

            var problem = new List<string>();
            for (int j = columnDigitLength - 1; j >= 0; j--)
            {
                var newDigitString = "";
                foreach (var digit in column)
                {
                    var digitString = digit[j];
                    newDigitString += digitString;
                }

                problem.Add(newDigitString.Trim());
            }

            ulong problemResult = 0;
            switch (problemOperator)
            {
                case "+":
                    foreach (var digit in problem)
                    {
                        problemResult += ulong.Parse(digit);
                    }
                    break;
                case "*":
                    problemResult = 1;
                    foreach (var digit in problem)
                    {
                        problemResult *= ulong.Parse(digit);
                    }
                    break;
            }

            var spacesToRemove = columnDigitLength + 1;
            input = input
                .Select(l => l.Length > spacesToRemove ? l[spacesToRemove..] : "")
                .ToArray();

            resultTotalPart2 += problemResult;
        }

        Console.WriteLine("Day 6 Part 1: " + resultTotalPart1);
        Console.WriteLine("Day 6 Part 2: " + resultTotalPart2);
    }
}
