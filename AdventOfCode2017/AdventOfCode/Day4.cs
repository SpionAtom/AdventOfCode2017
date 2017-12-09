using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day4_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            int noDoubles = 0;
            foreach (string line in lines)
            {                
                string[] words = line.Split(' ');                
                if (words.Length == words.Distinct().Count())
                {
                    noDoubles++;
                }
            }
            Console.WriteLine($"Solution Day 4 part 1: {noDoubles}");
        }
    }
}
