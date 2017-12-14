using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day14
    {
        public static void Part1()
        {
            string input = "xlqgujun";
            int ones = 0;
            
            for (int i = 0; i < 128; i++)
            {
                string line = $"{input}-{i}";
                string knotHash = GetKnotHash(line);
                

                // thx to https://stackoverflow.com/a/6617360
                string binarystring = String.Join(String.Empty, knotHash.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                  )
                );

                ones += binarystring.Count(f => f == '1');
            }

            Console.WriteLine($"Solution Day 14 part 1: {ones}");
        }

        private static int[,] grid = new int[128, 128];
        public static void Part2()
        {
            string input = "xlqgujun";
            
            string[] lines = new string[128];
            for (int i = 0; i < 128; i++)
            {
                string line = $"{input}-{i}";
                string knotHash = GetKnotHash(line);
                

                // thx to https://stackoverflow.com/a/6617360
                string binarystring = String.Join(String.Empty, knotHash.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                  )
                );
                lines[i] = knotHash + " " + binarystring;

                for (int c = 0; c < binarystring.Length; c++)
                {
                    if (binarystring[c] == '1')
                    {
                        grid[c, i] = 1;
                    }
                }                
            }

            //System.IO.File.WriteAllLines(@"Day14_output.txt", lines);

            int groups = 0;
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    if (grid[x, y] == 1)
                    {
                        groups++;
                        RemoveNeighboursAt(x, y);
                    }
                }
            }

            Console.WriteLine($"\nSolution Day 14 part 2: {groups}");

            char ch = '0';
            Console.WriteLine(15.ToString("X"));
        }

        private static void RemoveNeighboursAt(int x, int y)
        {
            grid[x, y] = 0;
            if (x > 0 && grid[x - 1, y] == 1)
            {
                RemoveNeighboursAt(x - 1, y);
            }
            if (x < 128 - 1 && grid[x + 1, y] == 1)
            {
                RemoveNeighboursAt(x + 1, y);
            }
            if (y > 0 && grid[x, y - 1] == 1)
            {
                RemoveNeighboursAt(x, y - 1);
            }
            if (y < 128 - 1 && grid[x, y + 1] == 1)
            {
                RemoveNeighboursAt(x, y + 1);
            }
        }

        public static string GetKnotHash(string inputString)
        {
            int[] input = inputString.ToCharArray().Select(c => (int)c).ToArray();
            int[] y = { 17, 31, 73, 47, 23 };
            var z = new int[input.Length + y.Length];
            input.CopyTo(z, 0);
            y.CopyTo(z, input.Length);
            input = z;

            int cycles = 256;
            int[] list = Enumerable.Range(0, cycles).ToArray();
            int skipSize = 0;
            int currentPosition = 0, pos;

            // 64 rounds of hashing
            for (int round = 0; round < 64; round++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    Stack<int> sublist = new Stack<int>();
                    for (int s = 0; s <= input[i] - 1; s++)
                    {
                        pos = (currentPosition + s) % list.Length;
                        sublist.Push(list[pos]);
                    }
                    for (int s = 0; s <= input[i] - 1; s++)
                    {
                        pos = (currentPosition + s) % list.Length;
                        list[pos] = sublist.Pop();
                    }
                    currentPosition = (currentPosition + input[i] + skipSize) % list.Length;
                    skipSize++;
                }
            }

            // calculate dense hash
            string knotHash = "";
            for (int b = 0; b < 16; b++)
            {
                int block = 0;
                for (int i = 0; i < 16; i++)
                {
                    block ^= list[b * 16 + i];
                }
                knotHash += block.ToString("X").PadLeft(2, '0');
            }

            return knotHash;
        }
        
    }
}
