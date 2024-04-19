using AoC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day4
    {
        private Card[] cardList;

        public void Solve()
        {
            string prefix = "Card   1:";
            string[] lines = File.ReadAllLines("Day4Input.txt");
            string[][] splitLines = lines.Select(l => l.Split('|')).ToArray();
            Regex numbEx = new Regex("\\d+");
            var winning = splitLines
            .Select(l => numbEx.Matches(l[0].Substring(prefix.Length))).ToArray();
            var drawn = splitLines
            .Select(l => numbEx.Matches(l[1])).ToArray();

            int totalScore = 0;
            int score = 0;
            int matches = 0;
            cardList = new Card[lines.Length];
            for (int i = 0; i < winning.Length; i++)
            {
                var curWinning = winning[i].Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
                var curDrawn = drawn[i].Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
                score = 0;
                matches = 0;
                foreach (var draw in curDrawn)
                {
                    if (curWinning.Contains(draw))
                    {
                        matches++;
                        switch (score)
                        {
                            case 0:
                                score = 1;
                                break;
                            default:
                                score *= 2;
                                break;

                        }
                    }
                }
                totalScore += score;
                cardList[i] = new Card(i, matches);

            }

            Console.WriteLine(totalScore);
            int totalCount = 0;
            foreach (var draw in cardList)
            {
                totalCount += ResolveCard(draw);
            }
            Console.WriteLine(totalCount);
        }

        record Card(int Index, int Matches);


        int ResolveCard(Card card)
        {
            int count = 1;
            for (int i = 0; i < card.Matches; i++)
            {
                if (card.Index + i < cardList.Length)
                {
                    count += ResolveCard(cardList[card.Index + i + 1]);
                }

            }
            return count;
        }

    }
}