using System;
using System.Collections;

public static class DayOne
{

    private static readonly Dictionary<String, String> numLookup = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" }
    };

    public static int Solve()
    {
        const string filePath = "01/input.txt";
        List<string> lines = new(File.ReadAllLines(filePath));
        int sum = 0;

        foreach (var line in lines)
        {
            var leftNum = String.Empty;
            var rightNum = String.Empty;

            var i = 0;
            while ((leftNum?.Length == 0 || rightNum?.Length == 0) && i < line.Length)
            {
                if (leftNum?.Length == 0)
                {
                    var strNum = line[i].ToString();
                    leftNum = int.TryParse(strNum, out int parsed) ? strNum : String.Empty;

                    if (leftNum?.Length == 0)
                    {
                        foreach (var numWord in numLookup.Keys)
                        {
                            if (leftNum != String.Empty || i + numWord.Length + 1 > line.Length) continue;
                            var numSubStr = line.Substring(i, numWord.Length);
                            leftNum = numLookup.TryGetValue(numSubStr, out string? value) ? value : String.Empty;
                        }
                    }
                }
                if (rightNum?.Length == 0)
                {
                    var index = line.Length - 1 - i;
                    var strNum = line[index].ToString();
                    rightNum = int.TryParse(strNum, out int parsed) ? strNum : String.Empty;

                    if (rightNum?.Length == 0)
                    {
                        foreach (var numWord in numLookup.Keys)
                        {
                            if (rightNum != String.Empty || index + 1 - numWord.Length < 0) continue;
                            var numSubStr = line.Substring(index + 1 - numWord.Length, numWord.Length);
                            rightNum = numLookup.TryGetValue(numSubStr, out string? value) ? value : String.Empty;
                        }
                    }
                }
                ++i;
            }

            sum += Int32.Parse(leftNum + rightNum);
        }
        return sum;
    }

}
