using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class Day10
    {
        private const int MAX = 256;
        public static void Part1()
        {
            int[] input = { 206, 63, 255, 131, 65, 80, 238, 157, 254, 24, 133, 2, 16, 0, 1, 3 };

            int[] list = new int[MAX];
            for (int i = 0; i < MAX; i++)
            {
                list[i] = i;
            }            
            int skipSize = 0;

            int currentPosition = 0, pos;
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
                Console.WriteLine(string.Join(",", list));
                skipSize++;
            }
            
            Console.WriteLine($"Solution Day 10 part 1: {list[0] * list[1]}");
        }

        public static void Part2()
        {
            // Calculate new input
            string inputstring = "206, 63, 255, 131, 65, 80, 238, 157, 254, 24, 133, 2, 16, 0, 1, 3";
            inputstring = inputstring.Replace(" ", "");
            int[] suffix = { 17, 31, 73, 47, 23 };
            int[] input = new int[suffix.Length + inputstring.Length];
            for (int i = 0; i < inputstring.Length; i++)
            {
                input[i] = inputstring[i];
            }
            for (int i = inputstring.Length; i < inputstring.Length + suffix.Length; i++)
            {
                input[i] = suffix[i - inputstring.Length];
            }

            Console.WriteLine("New input: " + string.Join(",", input));            

            int[] list = new int[MAX];
            for (int i = 0; i < MAX; i++)
            {
                list[i] = i;
            }
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
                    //Console.WriteLine(string.Join(",", list));
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
                knotHash += block.ToString("X");
            }
            Console.WriteLine($"Solution Day 10 part 2: {knotHash}");
        }
    }
}
