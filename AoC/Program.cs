// See https://aka.ms/new-console-template for more information


using AoC;
using System.Text.RegularExpressions;

//int Day1Result = Day1();
Day2 day2 = new Day2();
//day2.SolveDay2();
//Day3 day3 = new Day3();
//day3.SolveDay3();

//Day3_2 day3_2 = new Day3_2();
//day3_2.Solve();

//Day4 day4 = new Day4();
//day4.Solve();

//Day5 day5 = new Day5();
//day5.Solve();

//Day6 day6 = new Day6();
//day6.Solve();

Day7 day7 = new Day7();
day7.Solve();
int Day1()
{
    String[] lines = File.ReadAllLines("Day1Input.txt");

    int totalScore = 0;
    foreach (String line in lines)
    {
        string curLine = line;
        /*    curLine = curLine.Replace("one", "1");
            curLine = curLine.Replace("two", "2");
            curLine = curLine.Replace("three", "3");
            curLine = curLine.Replace("four", "4");
            curLine = curLine.Replace("five", "5");
            curLine = curLine.Replace("six", "6");
            curLine = curLine.Replace("seven", "7");
            curLine = curLine.Replace("eight", "8");
            curLine = curLine.Replace("nine", "9");*/

        int[] first = new int[9];
        first[0] = curLine.IndexOf("one");
        first[1] = curLine.IndexOf("two");
        first[2] = curLine.IndexOf("three");
        first[3] = curLine.IndexOf("four");
        first[4] = curLine.IndexOf("five");
        first[5] = curLine.IndexOf("six");
        first[6] = curLine.IndexOf("seven");
        first[7] = curLine.IndexOf("eight");
        first[8] = curLine.IndexOf("nine");
        int firstIndex = -1;
        int firstScore = -1;
        int curIndex = 0;
        foreach (int i in first)
        {
            curIndex++;
            if (i != -1)
            {
                if (firstIndex == -1 || i < firstIndex)
                {
                    firstIndex = i;
                    firstScore = curIndex;
                }
            }

        }

        int[] last = new int[9];
        last[0] = curLine.LastIndexOf("one");
        last[1] = curLine.LastIndexOf("two");
        last[2] = curLine.LastIndexOf("three");
        last[3] = curLine.LastIndexOf("four");
        last[4] = curLine.LastIndexOf("five");
        last[5] = curLine.LastIndexOf("six");
        last[6] = curLine.LastIndexOf("seven");
        last[7] = curLine.LastIndexOf("eight");
        last[8] = curLine.LastIndexOf("nine");
        int lastIndex = -1;
        int lastScore = -1;
        curIndex = 0;
        foreach (int i in last)
        {
            curIndex++;
            if (i != -1)
            {
                if (lastIndex == -1 || i > lastIndex)
                {
                    lastIndex = i;
                    lastScore = curIndex;
                }
            }

        }

        String scoreString = "";
        curIndex = -1;
        foreach (Char c in curLine)
        {
            curIndex++;
            if (Char.IsNumber(c))
            {
                if (firstIndex == -1 || curIndex < firstIndex)
                {
                    scoreString += c;
                }
                else
                {
                    scoreString += firstScore.ToString();
                }
                break;
            }
        }
        curIndex = line.Length;
        foreach (Char c in curLine.Reverse())
        {
            curIndex--;
            if (Char.IsNumber(c))
            {
                if (lastIndex == -1 || curIndex > lastIndex)
                {
                    scoreString += c;
                }
                else
                {
                    scoreString += lastScore.ToString();
                }
                break;
            }
        }
        int score = Int32.Parse(scoreString);
        totalScore += score;
        Console.WriteLine(curLine + " Score = " + score + " New Total Score: " + totalScore);

    }
    return totalScore;

}


