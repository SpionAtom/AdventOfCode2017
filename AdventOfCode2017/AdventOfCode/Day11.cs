using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Day11
    {
        public static void Part1()
        {
            string input = File.ReadAllText("data/Day11_input.txt");
            string[] directions = input.Split(',');

            int x = 0, y = 0;
            int distance = 0, maxDistance = int.MinValue;
            foreach (string dir in directions)
            {
                switch (dir)
                {
                    case "n":
                        y++;
                        break;
                    case "s":
                        y--;
                        break;
                    case "nw":
                        x--;
                        break;
                    case "sw":
                        x--;
                        y--;
                        break;
                    case "ne":
                        x++;
                        y++;
                        break;
                    case "se":
                        x++;
                        break;
                }

                if (x < 0 && y < 0 || x > 0 && y > 0)
                {
                    distance = Math.Max(Math.Abs(x), Math.Abs(y));
                }
                else
                {
                    distance = Math.Abs(x) + Math.Abs(y);
                }

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }

            Console.WriteLine($"Solution Day 12 part 1/2: x {x} y {y} -> final distance: {distance}  max distance: {maxDistance}");
        }

        public static void Part2()
        {
            Part1();
        }
    }
}
