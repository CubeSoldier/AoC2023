using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day2
    {

        public void SolveDay2()
        {
            string[] lines = File.ReadAllLines("Day2Input.txt");
            Game[] games = new Game[lines.Length];
            int index = 0;
            foreach (String line in lines)
            {
                games[index] = new Game(line);
                index++;
            }
            Console.WriteLine("All games processed");
            Console.WriteLine(Day2Part1(games));
            Console.WriteLine(Day2Part2(games));
        }

        int Day2Part1(Game[] games)
        {
            int maxRedCubes = 12;
            int maxGreenCubes = 13;
            int maxBlueCubes = 14;
            int totalID = 0;
            bool valid;

            foreach (Game game in games)
            {
                valid = true;
                foreach (Draw draw in game.draws)
                {
                    if (draw.Red > maxRedCubes || draw.Green > maxGreenCubes || draw.Blue > maxBlueCubes)
                    {
                        Console.WriteLine(game.Id + " is impossible New Score: +" + totalID);
                        valid = false;
                        break;
                    }

                }
                if (valid)
                {
                    totalID += game.Id;
                }

            }
            return totalID;
        }

        int Day2Part2(Game[] games)
        {
            int totalPow = 0;
            int minRed;
            int minGreen;
            int minBlue;
            foreach (Game game in games)
            {
                minRed = 0;
                minGreen = 0;
                minBlue = 0;
                foreach (Draw draw in game.draws)
                {
                    if (draw.Red > minRed)
                    {
                        minRed = draw.Red;
                    }
                    if (draw.Green > minGreen)
                    {
                        minGreen = draw.Green;
                    }
                    if ((draw.Blue > minBlue))
                    {
                        minBlue = draw.Blue;
                    }
                }
                int pow = minRed * minGreen * minBlue;
                Console.WriteLine("R: " + minRed + " * " + " G: " + minGreen + " B: " + minBlue + " = " + pow);
                totalPow += pow;
                Console.WriteLine("Power of Game " + game.Id + ": " + pow + " New Total Power: " + totalPow);
            }


            return totalPow;
        }

        class Game
        {

            int id = -1;
            public List<Draw> draws { get; set; }
            public int Id { get => id; set => id = value; }

            public Game(String line)
            {
                Id = parseIDFromLine(line);
                Console.WriteLine("Game ID: " + Id);
                draws = parseDrawsFromLine(line);
            }


            int parseIDFromLine(String line)
            {
                Regex gameIdExtractor = new Regex("Game (\\d+):");
                GroupCollection groups = gameIdExtractor.Match(line).Groups;
                return int.Parse(groups[1].Value);
            }
            List<Draw> parseDrawsFromLine(String line)
            {
                List<Draw> draws = new List<Draw>();
                Regex drawExtractor = new Regex("[^;]+");
                MatchCollection matchCollection = drawExtractor.Matches(line);
                foreach (Match match in matchCollection)
                {
                    Regex redExtractor = new Regex("(\\d+) red");
                    Regex blueExtractor = new Regex("(\\d+) blue");
                    Regex greenExtractor = new Regex("(\\d+) green");
                    int red = 0;
                    int blue = 0;
                    int green = 0;
                    string value = match.Value;
                    if (redExtractor.Match(value).Success)
                    {
                        red = int.Parse(redExtractor.Match(value).Groups[1].Value);
                    }
                    if (blueExtractor.Match(value).Success)
                    {
                        blue = int.Parse(blueExtractor.Match(value).Groups[1].Value);
                    }
                    if (greenExtractor.Match(value).Success)
                    {
                        green = int.Parse(greenExtractor.Match(value).Groups[1].Value);
                    }

                    Draw draw = new Draw(red, blue, green);
                    draws.Add(draw);
                }

                return draws;
            }
        }
        class Draw

        {
            private int red;
            private int blue;
            private int green;

            public Draw(int red, int blue, int green)
            {
                this.Red = red;
                this.Blue = blue;
                this.Green = green;
            }

            public int Red { get => red; set => red = value; }
            public int Blue { get => blue; set => blue = value; }
            public int Green { get => green; set => green = value; }
        }

    }
}
