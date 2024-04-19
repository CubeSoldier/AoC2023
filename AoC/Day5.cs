using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day5
    {
        Regex mappingsRegex = new Regex("(.+)-to-([\\S]+\\S)");
        Regex numbersRegex = new Regex("\\d+");
        private List<Mapping>[]? mappings;



        record Mapping (long destRange, long srcRange, long length);
        record Map (string From, string To, List<Mapping> Mappings);

        public void Solve() {

            string lines = File.ReadAllText("Day5Input.txt");
            string[][] splitLines = lines.Split("\r\n\r\n").Select(a => a.Split("\r\n")).ToArray();
            long[] seeds = numbersRegex.Matches(splitLines[0][0]).Select(i => long.Parse(i.Value)).ToArray();
            List<Map> maps = new List<Map>();
            mappings = new List<Mapping>[splitLines.Length - 1];
            long maxAlloc = 0;
            for (int i = 1; i < splitLines.Length; i++)
            {
                mappings[i-1] = new List<Mapping> ();
                for (int j = 1; j < splitLines[i].Length; j++)
                {
                    var matches = numbersRegex.Matches(splitLines[i][j]);
                    foreach (Match match in matches)
                    {
                        if (long.Parse(match.Value) > maxAlloc)
                        {
                            maxAlloc = long.Parse(match.Value);
                        }
                    }
                    mappings[i-1].Add(new Mapping(long.Parse(matches[0].Value), long.Parse(matches[1].Value), long.Parse(matches[2].Value)));
                }
            }
/*            long[][] seedToLocMaps = new long[mappings.Length][];
            //Dictionary<long, long>[] map = new Dictionary<long, long>[];
            for (int i = 0; i < mappings.Length; i++)
            {
                foreach (var mapping in mappings[i]) { 
                    for (int j = 0; j < mapping.length; j++)
                    {
                        seedToLocMaps[i][mapping.srcRange + j] = mapping.destRange + j;
                    }
                }
            }*/

            long lowestScore = long.MaxValue;
            // Part 1
            foreach (long seed in seeds) {
                long index = seed;
                /*                for (int j = 0; j < mappings.Length; j++)
                                {



                                     if (seedToLocMaps[j][index] != null)
                                    {
                                        index = seedToLocMaps[j][index];

                                    }
                                }*/

                index = seedToLocation(seed, 0);
                if (index < lowestScore)
                {
                    Console.WriteLine("New Lowest Score found: " + index);
                    lowestScore = index;
                }
            }
            Console.WriteLine(lowestScore);

            //Part 2
            lowestScore = long.MaxValue;
            for (int i = 0; i < seeds.Length; i = i + 2) {

                for (int j = 0; j < seeds[i+1]; j++)
                {
                    long result = seedToLocation(seeds[i] + j, 0);
                    if (result < lowestScore)
                    {
                        Console.WriteLine("New Lowest Score found: " + result);
                        lowestScore = result;
                    }
                }

            }
            Console.WriteLine(lowestScore);
        }


        long seedToLocation (long seed, int depth)
        {
            if (depth == this.mappings.Length)
            {
                return seed;
            }

            foreach (Mapping mapping in this.mappings[depth])
            {
                if (mapping.srcRange <= seed && seed < (mapping.srcRange + mapping.length))
                {
                    if (depth == this.mappings.Length)
                    {
                        return mapping.destRange + (seed - mapping.srcRange);
                    }
                    return seedToLocation(mapping.destRange + (seed - mapping.srcRange), depth + 1);

                }
            }

            return seedToLocation(seed, depth + 1);
        }

    }
}
