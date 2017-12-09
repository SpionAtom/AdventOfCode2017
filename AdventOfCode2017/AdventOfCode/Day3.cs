using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class Day3
    {
        public static void Part1()
        {
            int input = 368078;

            int square = 1;
            while (input > square * square)
            {
                square += 2;
            }
            int mh = square / 2 * 2;
            int diff;

            Console.WriteLine($"input {input}, square {square}");

            // untere Kante
            if (input > square * square - 1 * square + 1)
            {
                diff = Math.Abs(((square * square - 1 * square + 1) + square / 2) - input);
                mh -= (square / 2 - diff);
            }
            // linke Kante
            else if (input > square * square - 2 * square + 2)
            {
                diff = Math.Abs(((square * square - 2 * square + 2) + square / 2) - input);
                mh -= (square / 2 - diff);
            }
            // obere Kante
            else if (input > square * square - 3 * square + 3)
            {
                diff = Math.Abs(((square * square - 3 * square + 3) + square / 2) - input);
                mh -= (square / 2 - diff);
            }
            // rechte Kante
            else
            {
                diff = Math.Abs(((square * square - 4 * square + 4) + square / 2) - input);
                mh -= (square / 2 - diff);
            }

            Console.WriteLine($"Solution Day 3 part 1: Manhatten distance: {mh}");            
        }

        public static void Part2()
        {
            // init work
            int input = 368078;
            int centerX = 500, centerY = 500;
            int[,] spiral = new int[2 * centerX, 2 * centerY];
            spiral[centerX, centerY] = 1;

            // now move along and fill the array
            int currentX = centerX + 1, currentY = centerY;
            int value;

            do
            {
                value = GetValue(currentX, currentY, spiral);
                spiral[currentX, currentY] = value;
                
                // left occupied and above free
                if (spiral[currentX - 1, currentY] != 0 && spiral[currentX, currentY - 1] == 0)
                {
                    currentY--;
                }
                // left free and beneath occupied
                else if (spiral[currentX - 1, currentY] == 0 && spiral[currentX, currentY + 1] != 0)
                {
                    currentX--;
                }
                // right occupied and below free
                else if (spiral[currentX + 1, currentY] != 0 && spiral[currentX, currentY + 1] == 0)
                {
                    currentY++;
                }
                else
                {
                    currentX++;
                }
            }
            while (value < input);

            Console.WriteLine($"Solution Day 3 part 2: {value}");
        }

        private static int GetValue(int x, int y, int[,] array)
        {
            int sum = 0;
            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {                    
                    if (i != 0 && j != 0)
                    {
                        sum += array[i, j];
                    }
                }                
            }

            return sum;
        }


    }
}
