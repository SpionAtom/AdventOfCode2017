using System;
using System.IO;
using System.Linq;

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

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day4_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            int valids = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                if (words.Length == words.Distinct().Count())
                {
                    bool foundAnagram = false;
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        for (int j = i + 1; j < words.Length; j++)
                        {
                            if (IsAnagram(words[i], words[j]))
                            {
                                foundAnagram = true;
                            }
                        }
                    }
                    if (!foundAnagram)
                    {
                        valids++;
                    }                    
                }
            }
            Console.WriteLine($"Solution Day 4 part 2: {valids}");
        }

        private static bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                var countA = a.Count(x => x == a[i]);
                var countB = b.Count(x => x == a[i]);
                if (countA != countB)
                {
                    return false;
                }
            }           

            return true;
        }
    }
}
