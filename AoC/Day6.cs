using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day6
    {
        internal void Solve()
        {
            Regex numbersRegex = new Regex("\\d+");
            string[] input = File.ReadAllLines("Day6Input.txt");
            int[] time = numbersRegex.Matches(input[0]).Select(t => int.Parse(t.Value)).ToArray();
            int[] records = numbersRegex.Matches(input[1]).Select(t => int.Parse(t.Value)).ToArray();
            long totalResult = 1;
            for (int i = 0; i < time.Length; i++)
            {
                long result = calcRaceWaysToWin(time[i], records[i]);
                if (result > 0)
                {
                    totalResult *= result;
                }
            }
            Console.WriteLine(totalResult);

            long time2 = long.Parse(numbersRegex.Matches(input[0]).Select(t => t.Value).Aggregate((a, b) => a + b));
            long record2 = long.Parse(numbersRegex.Matches(input[1]).Select(t => t.Value).Aggregate((a, b) => a + b));

            totalResult = calcRaceWaysToWin(time2, record2);
            Console.WriteLine(totalResult);
        }

        long calcRaceWaysToWin (long time, long record)
        {
            int ways = 0;
            bool beaten = false;
            for (int i = 1; i <= time; i++)
            {
                long distance = i * (time- i);
                if (distance > record)
                {
                    beaten = true;
                    ways++;
                } else if (beaten)
                {
                    break;
                }
            }

            return ways;
        }
    }
}
