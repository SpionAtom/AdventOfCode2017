using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day12
    {
        private static Input[] inputs;        
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day12_input_example.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            List<string> zerobucket = new List<string>();
            List<string> toVisit = new List<string>();
            toVisit.Add("0");
            while (toVisit.Count > 0)
            {
                var first = toVisit.First();
                if (!zerobucket.Contains(first))
                {
                    zerobucket.Add(first);
                }
                toVisit.RemoveAt(0);

                foreach(var neighbour in inputs.Where(i => i.Program == first).Single().Neighbours)
                {
                    if (!zerobucket.Contains(neighbour))
                    {
                        toVisit.Add(neighbour);
                    }                    
                }
            }            

        Console.WriteLine($"Solution Day 12 part 1: {zerobucket.Count}");
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day12_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            List<string> notInBucket = new List<string>();
            for (int i = 0; i < 2000; i++)
            {
                notInBucket.Add(i.ToString());
            }
            List<string> bucket = new List<string>();
            List<string> toVisit = new List<string>();

            int groups = 0;

            while (notInBucket.Count > 0)
            {
                groups++;
                toVisit.Add(notInBucket.First());

                while (toVisit.Count > 0)
                {
                    var first = toVisit.First();
                    if (!bucket.Contains(first))
                    {
                        bucket.Add(first);
                    }
                    toVisit.RemoveAt(0);

                    var neighboursOfFirst = inputs.Where(i => i.Program == first).Single().Neighbours;
                    foreach (var neighbour in neighboursOfFirst)
                    {
                        if (!bucket.Contains(neighbour))
                        {
                            toVisit.Add(neighbour);
                        }
                    }
                }

                foreach(var b in bucket)
                {
                    notInBucket.Remove(b);
                }
            }

            Console.WriteLine($"\nSolution Day 12 part 2: {groups}");
        }

        private class Input
        {
            public string Program { get; set; }            
            public string[] Neighbours { get; set; }

            public Input(string line)
            {
                string[] parts = line.Split(new string[] { " <-> " }, StringSplitOptions.None);
                Program = parts[0];
                
                if (parts.Length == 1)
                {
                    Neighbours = null;
                }
                else
                {
                    Neighbours = parts[1].Split(new string[] { ", " }, StringSplitOptions.None);
                }
            }
        }
    }
}
