using System;
using System.Collections;
using System.Numerics;

public static class DayTwo
{
    public static int Solve()
    {
        int sum = 0;
        var lines = File.ReadAllLines("02/input.txt").Select(l =>
        {
            var index = l.IndexOf(':');
            return l.Substring(index + 1);
        });

        var rounds = lines.Select(l => l.Split(';').Select(s => s.Trim()));
        var drawings = rounds.Select(r => r.Select(d => d.Split(',').Select(s => s.Trim())));
        var parsed = drawings.Select(g => g.Select(r => r.Select(d =>
        {
            var split = d.Split(' ');
            return new Tuple<string, int>(split[1], Int32.Parse(split[0]));
        }))).ToList();

        for (var i = 0; i < parsed.Count; ++i)
        {
            var game = parsed[i];
            var minGreen = 0;
            var minRed = 0;
            var minBlue = 0;

            foreach (var round in game)
            {
                foreach (var draw in round)
                {
                    switch (draw.Item1)
                    {
                        case "red":
                            minRed = Math.Max(minRed, draw.Item2);
                            break;
                        case "green":
                            minGreen = Math.Max(minGreen, draw.Item2);
                            break;
                        case "blue":
                            minBlue = Math.Max(minBlue, draw.Item2);
                            break;
                    }
                }
            }

            sum += minGreen * minRed * minBlue;
        }

        return sum;
    }
}
