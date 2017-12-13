using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day13
    {
        private static Input[] inputs;
        public static void Part1()
        {
            string readText = File.ReadAllText("data/Day13_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            int severity = 0;
            foreach(var i in inputs)
            {
                if (i.Layer % (2 * (i.Range - 1)) == 0)
                {
                    severity += i.Layer * i.Range;
                }                
            }

            Console.WriteLine($"Solution Day 13 part 1: {severity}");
        }

        public static void Part2()
        {
            string readText = File.ReadAllText("data/Day13_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            // lazy brute force            
            int delay = 0;
            bool caught = true;
            while (caught)
            {
                caught = false;
                foreach (var i in inputs)
                {
                    if ((i.Layer + delay) % ((i.Range - 1) * 2) == 0)
                    {
                        caught = true;
                        delay++;
                        //Console.WriteLine($"with delay {delay} the packet is caught at {i.Layer}");
                        break;
                    }
                }
            }

            Console.WriteLine($"\nSolution Day 13 part 2: {delay}");
        }

        private class Input
        {
            public int Layer { get; set; }
            public int Range { get; set; }

            public Input(string line)
            {
                string[] s = line.Split(':');
                this.Layer = int.Parse(s[0]);
                this.Range= int.Parse(s[1]);
            }
        }
         

    }
}
