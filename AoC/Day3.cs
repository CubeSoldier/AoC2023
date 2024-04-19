using AoC.Properties;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day3
        
    {
        char[][] data;
        public void SolveDay3 ()
        {
            string input = Properties.Resources.Day3Input;
            string[] inputLines = input.Split("\n");
            for (int i = 0; i < inputLines.Length; i++)
            {
                inputLines[i] = inputLines[i].Replace("\n", string.Empty);
                inputLines[i] = inputLines[i].Replace("\r", string.Empty);
                inputLines[i] = inputLines[i].Replace("\t", string.Empty);
            }
            data = inputLines.Select(item => item.ToArray()).ToArray();
            Console.WriteLine(Part1(data));

        }

        int Part1(char[][] data)
        {
            int sum = 0;
            List<int> partList = new List<int>();
            int numberLength = 0;
            string result = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    
                    if (char.IsNumber(data[i][j])){
                        result += data[i][j];
                        numberLength++;
                        if (j == data[i].Length - 1)
                        {
                            Console.WriteLine("END " + result);
                            if (CheckValidity(i, j, numberLength))
                            {
                                int partNr = int.Parse(result);
                                if (!partList.Contains(partNr))
                                {
                                    partList.Add(partNr);
                                    sum += partNr;
                                    Console.WriteLine("Row " + i + " Col " + j + " is correct Score: " + result + " Total Score: " + sum);
                                }
                                else Console.WriteLine("Part " + partNr + " already contained");
                            }
                            numberLength = 0;
                            result = string.Empty;
                        }
                    } else if ( numberLength > 0)
                    {
                        Console.WriteLine(result);
                        if (CheckValidity(i, j, numberLength)) {
                            int partNr = int.Parse(result);
                            if (!partList.Contains(partNr))
                            {
                                partList.Add(partNr);
                                sum += partNr;
                                Console.WriteLine("Row " + i + " Col " + j + " is correct Score: " + result + " Total Score: " + sum);
                            }
                            else Console.WriteLine("Part " + partNr + " already contained");
                        }
                        numberLength = 0;
                        result = string.Empty;
                    }
                }
            }
            return sum;
        }

        bool CheckValidity (int i,  int j, int numberLength)
        {
            //Check same row front and back
            if ((j < data[i].Length && IsSymbol(data[i][j])) || (  j- numberLength - 1 >= 0 && IsSymbol( data[i][j-numberLength-1]))) 
            {
                Console.WriteLine("Symbol "+ data[i][j] +" in same line detected. Valid!");
                return true;
            }
            //Check above and below rows
            for (int i2 = j - numberLength - 1; i2 < j + 1; i2++)
            {
                if ((i2 < data[i].Length && i2 >= 0) )
                {
                    if (i - 1 >= 0 && IsSymbol(data[i - 1][i2])) {
                        Console.WriteLine("Symbol " + data[i - 1][i2] + " detected in previous line. Valid!");
                        return true;
                    }
                    else if (i + 1 < data.Length && IsSymbol(data[i + 1][i2]))
                    {
                        Console.WriteLine("Symbol " + data[i + 1][i2] + " detected in next line. Valid!");
                        return true;
                    }
                    {
                        
                    }

                }
            }
            return false;
        }

        bool IsSymbol (char character)
        {
            if (!char.IsDigit(character) && character != '.' && character != '\n') {
                return true;
            }
            else { return false; }
        } 

    }
}
