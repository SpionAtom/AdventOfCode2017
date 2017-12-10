using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public class Day6
    {
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day6_input.txt");
            string[] inputs = readText.Split('\t');
            int[] numbers = inputs.Select(s => int.Parse(s)).ToArray();
            List<string> history = new List<string>();

            while (history.Count == history.Distinct().Count())
            {
                Console.WriteLine(string.Join(",", numbers));                
                history.Add(string.Join(",", numbers));
                int current = numbers.ToList().IndexOf(numbers.Max()); // biggest memory block
                int amount = numbers[current];
                numbers[current] = 0;
                for (int a = amount; a > 0; a--)
                {
                    current++;
                    numbers[current % numbers.Count()]++;
                }
            }

            Console.WriteLine($"Solution Day 6 part 1: {history.Count - 1}");
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day6_input.txt");
            string[] inputs = readText.Split('\t');
            int[] numbers = inputs.Select(s => int.Parse(s)).ToArray();
            List<string> history = new List<string>();

            while (history.Count == history.Distinct().Count())
            {
                Console.WriteLine(string.Join(",", numbers));
                history.Add(string.Join(",", numbers));
                int current = numbers.ToList().IndexOf(numbers.Max()); // biggest memory block
                int amount = numbers[current];
                numbers[current] = 0;
                for (int a = amount; a > 0; a--)
                {
                    current++;
                    numbers[current % numbers.Count()]++;
                }
            }

            // count loop cycles
            string last = history.Last();
            int loopCount = 0;
            do
            {
                loopCount++;
                history.RemoveAt(history.Count - 1);
            }
            while (history.Last() != last);

            Console.WriteLine($"Solution Day 6 part 1: {loopCount}");
        }
    }
}
