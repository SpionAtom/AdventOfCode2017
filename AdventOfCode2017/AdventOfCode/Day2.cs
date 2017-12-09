using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Day2
    {
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day2_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);

            int sum = 0;
            foreach (string line in lines)
            {
                int highest = 0, lowest = Int32.MaxValue;

                string[] numbers = line.Split(',');
                foreach (string number in numbers)
                {
                    int value = Convert.ToInt32(number.ToString());
                    if (value < lowest)
                    {
                        lowest = value;
                    }
                    if (value > highest)
                    {
                        highest = value;
                    }
                }
                int diff = highest - lowest;
                // Console.WriteLine($"lowest {lowest}, highest {highest}, Diff {diff}");
                sum += diff;
            }
            Console.WriteLine($"Solution Day 2 part 1: {sum}");
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day2_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);

            int sum = 0;
            foreach (string line in lines)
            {
                int value1, value2;

                string[] numbers = line.Split(',');
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    value1 = Convert.ToInt32(numbers[i].ToString());
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        value2 = Convert.ToInt32(numbers[j].ToString());
                        if (value1 % value2 == 0)
                        {
                            sum += value1 / value2;
                        }
                        else if (value2 % value1 == 0)
                        {
                            sum += value2 / value1;
                        }
                    }
                }                
            }
            Console.WriteLine($"Solution Day 2 part 2: {sum}");
        }
    }
}
