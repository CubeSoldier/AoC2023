using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day7
    {
        static readonly char[] sequence = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
        static readonly char[] sequenceDesc = sequence.Reverse().ToArray();
        record Hand (string cards, int Bid)
        {

            int Rank ()
            {
                for (int i = 0; i < sequenceDesc.Length; i++) {
                
                }
            }
        }

        public void Solve ()
        {

            string[] input = File.ReadAllLines("Day7Test.txt");
            string[][] splitInput = input.Select(a => a.Split(' ')).ToArray();
            List<Hand> handList = new List<Hand>();
            foreach (string[] inputSplit in splitInput) { 
                handList.Add(new Hand(inputSplit[0], int.Parse(inputSplit[1])));
            }

            for (int i = 0; i < splitInput.Length; i++)
            {

            }
        }


    }
}
