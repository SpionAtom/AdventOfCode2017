using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day07
    {
        private static Input[] inputs;        
        public static string Part1(bool output = true)
        {
            string readText = File.ReadAllText("data/Day7_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            // find the name that is not listed in any children
            string root = string.Empty;
            for (int i = 0; i < inputs.Length; i++)
            {
                bool rootFound = true;
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (i != j)
                    {
                        if (inputs[j].Children != null)
                        {
                            if (inputs[j].Children.Contains(inputs[i].Name))
                            {
                                rootFound = false;
                                break;
                            }
                        }
                    }
                }

                if (rootFound)
                {
                    root = inputs[i].Name;
                    break;
                }
            }            

            if (output)
            {
                Console.WriteLine($"Solution Day 7 part 1: root {root}");
            }
            
            return root;
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day7_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            string root = Part1(false);
            Input current = GetInput(root);

            Weight(current);

            Console.WriteLine($"Solution Day 7 part 2: {root}");
        }

        private static int Weight(Input input)
        {
            //Console.WriteLine($"{input.Name} ({input.Weight})");
            int sum = input.Weight;
            int childrensWeight = 0;
            if (input.Children == null)
            {
                childrensWeight = 0;
            }
            else
            {
                List<int> weights = new List<int>();
                foreach (string child in input.Children)
                {
                    int w = Weight(GetInput(child));                    
                    childrensWeight += w;
                    weights.Add(w);
                }
                Console.WriteLine($"Children of {input.Name}");
                Console.WriteLine(string.Join(",", input.Children));
                Console.WriteLine(string.Join(",", weights));
                if (weights.Distinct().Count() != 1)
                {
                    Console.WriteLine("^ unbalance found ****************************************");
                }
            }            
            return sum + childrensWeight;
        }

        private static Input GetInput(string name)
        {
            foreach (var input in inputs)
            {
                if (input.Name == name)
                {
                    return input;
                }
            }
            return null;
        }

        private class Input
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public string[] Children { get; set; }

            public Input(string line)
            {
                string[] parts = line.Split(new string[] { " -> " }, StringSplitOptions.None);                
                Name = parts[0].Split(' ')[0];
                Weight = int.Parse(Regex.Match(parts[0], @"\(([^)]*)\)").Groups[1].Value);
                if (parts.Length == 1)
                {
                    Children = null;
                }
                else
                {
                    Children = parts[1].Split(new string[] { ", " }, StringSplitOptions.None);
                }
                
            }
        }
    }
}
