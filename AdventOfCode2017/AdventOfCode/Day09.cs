using System;
using System.IO;

namespace AdventOfCode
{
    public class Day09
    {
        public static void Part1()
        {
            string stream = File.ReadAllText("data/Day9_input.txt");            
            string cleaned = CleanStream(stream);
            int score = StreamValue(cleaned);

            Console.WriteLine("Stream:  " + stream);
            Console.WriteLine("Cleaned: " + cleaned);

            Console.WriteLine($"Solution Day 9 part 1: {score}");
        }

        public static void Part2()
        {
            string stream = File.ReadAllText("data/Day9_input.txt");            
            string cleaned = CleanStream(stream, true);
        }

        private static int StreamValue(string stream)
        {
            int depth = 1;
            int value = 1;
            
            for (int i = 1; i < stream.Length; i++)            
            {
                if (stream[i] == '{' && stream[i - 1] == '{')
                {
                    depth = depth + 1;                    
                }
                if (stream[i] == '}' && stream[i - 1] == '}')
                {
                    depth = depth - 1;
                }
                if (stream[i] == '{')
                {
                    value = value + depth;
                }                
            }

            return value;
        }

        private static string CleanStream(string stream, bool outputGargabeAmount = false)
        {
            string cleaned = string.Empty;
            bool insideGarbage = false;
            bool exclamation = false;
            int garbageAmount = 0;

            for (int i = 0; i < stream.Length; i++)
            {                
                if (!insideGarbage)
                {
                    if (stream[i] != '<')
                    {
                        if (stream[i] != ',')
                        {
                            cleaned += stream[i];
                        }                        
                    }                    
                    else
                    {
                        // a wild garbage appears
                        insideGarbage = true;
                        exclamation = false;
                    }                    
                }
                else
                {
                    // when inside garbage await closing '>' which is not negated.
                    if (!exclamation && stream[i] == '!')
                    {
                        exclamation = true;
                    }
                    else if (exclamation)
                    {
                        exclamation = false;
                    }
                    else if (!exclamation && stream[i] == '>')
                    {
                        insideGarbage = false;
                    }
                    else
                    {
                        garbageAmount++;
                    }
                }
            }

            if (outputGargabeAmount)
            {
                Console.WriteLine($"Solution Day 9 part 2: {garbageAmount}");
            }

            return cleaned;
        }
    }
}
