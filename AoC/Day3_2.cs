using AoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day3_2
    {

        public void Solve()
        {
            Regex numberRegex = new Regex(@"\d+");
            Regex symbolRegex = new Regex("[^.\\d\\n]");

            string input = Resources.Day3Input;
            string[] inputLines = input.Split("\n");

            List<Number> numbers = new List<Number>();
            List<Symbol> symbols = new List<Symbol>();
            int lineIndex = 0;
            foreach (string line in inputLines)
            {
                foreach (Match numberMatch in numberRegex.Matches(line))
                {
                    numbers.Add(new Number(int.Parse(numberMatch.Value), new Coords(numberMatch.Index, lineIndex)));
                }
                foreach (Match symMa in symbolRegex.Matches(line))
                {
                    symbols.Add(new Symbol (new Coords(symMa.Index, lineIndex)));
                }

                lineIndex++;

            }
            var partSum = numbers.Where(n => symbols.Any(s => s.Coords.isAdjacent(n))).DistinctBy(i => i.Value).Sum(i => i.Value);
            Console.WriteLine(partSum);

        }


        record Coords(int X, int Y)
        {
            public bool isAdjacent(Number number)
            {
                if (Y > number.Coords.Y + 1 || Y < number.Coords.Y - 1)
                {
                    return false;
                }

                return (X < number.Coords.X - 1 || X > number.Coords.X + number.Value.ToString().Length + 1);



            }
        };

        record Number(int Value, Coords Coords);

        record Symbol(Coords Coords);
    }
}
