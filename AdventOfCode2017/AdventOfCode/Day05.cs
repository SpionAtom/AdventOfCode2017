using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day05
    {
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day5_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            int[] numbers = lines.Select(s => int.Parse(s)).ToArray();

            int currentPosition = 0;
            int jumps = 0;
            while (currentPosition < lines.Length)
            {
                jumps++;
                numbers[currentPosition]++;
                currentPosition += numbers[currentPosition] - 1;
            }            

            Console.WriteLine($"Solution Day 5 part 1: {jumps}");
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day5_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            int[] numbers = lines.Select(s => int.Parse(s)).ToArray();

            int currentPosition = 0;
            int jumps = 0;
            while (currentPosition < lines.Length)
            {
                jumps++;
                if (numbers[currentPosition] < 3)
                {
                    numbers[currentPosition]++;
                    currentPosition += numbers[currentPosition] - 1;
                }
                else
                {
                    numbers[currentPosition]--;
                    currentPosition += numbers[currentPosition] + 1;
                }                
            }

            Console.WriteLine($"Solution Day 5 part 2: {jumps}");
        }
    }
}
