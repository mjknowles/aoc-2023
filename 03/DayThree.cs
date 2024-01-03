using System;
using System.Collections;
using System.Numerics;
using System.Text;

public static class DayThree
{
    public static int Solve()
    {
        int sum = 0;
        var graph = File.ReadAllLines("03/example.txt").Select(l => l.ToCharArray()).ToArray();

        var queue = new Queue<int[]>();

        while (queue.Count > 0)
        {
            int[] curr = queue.Dequeue();
            int x = curr[0];
            int y = curr[1];
            if (graph[x][y] == '.') continue;
            else if (!char.IsDigit(graph[x][y]))
            {
                if (y > 0)
                    queue.Enqueue([x, y - 1]);
                if (x < graph[0].Length - 1)
                    queue.Enqueue([x + 1, y]);
                if (y < graph.Length - 1)
                    queue.Enqueue([x, y + 1]);
                if (x > 0)
                    queue.Enqueue([x - 1, y]);
                graph[x][y] = '.';
            }
            else
            {
                var sb = new StringBuilder(graph[x][y]);
                var i = x - 1;
                while (i >= 0 && char.IsNumber(graph[i][y]))
                {
                    sb.Insert(0, graph[i][y]);
                    graph[i--][y] = '.';
                }

                i = x + 1;
                while (i < graph[0].Length && char.IsNumber(graph[i][y]))
                {
                    sb.Append(graph[i][y]);
                    graph[i++][y] = '.';
                }

                sum += Int32.Parse(sb.ToString());
            }
        }

        return sum;
    }
}
