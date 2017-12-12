using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day08
    {
        private static Input[] inputs;
        private static List<Register> registers;
        private static int biggestRegisterValue;

        public static int Part1(bool output = true)
        {
            biggestRegisterValue = int.MinValue;
            string readText = File.ReadAllText("data/Day8_input.txt");
            string[] lines = readText.Split(new[] { Environment.NewLine },
                                                    StringSplitOptions.None);
            inputs = lines.Select(s => new Input(s)).ToArray();

            // register all registers
            registers = new List<Register>();
            foreach (var input in inputs)
            {
                var query =
                    from Register register in registers
                    where register.Name == input.Register
                    select register;

                if (!query.Any())
                {
                    registers.Add(new Register(input.Register));
                }
            }

            // perform instructions
            foreach (var input in inputs)
            {
                switch (input.ConOperator)
                {
                    case Condition.equals:
                        if (GetValueOf(input.ConRegister) == input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    case Condition.notequals:
                        if (GetValueOf(input.ConRegister) != input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    case Condition.greaterthan:
                        if (GetValueOf(input.ConRegister) > input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    case Condition.lessthan:
                        if (GetValueOf(input.ConRegister) < input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    case Condition.greateroreven:
                        if (GetValueOf(input.ConRegister) >= input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    case Condition.lessoreven:
                        if (GetValueOf(input.ConRegister) <= input.ConValue)
                        {
                            AddToRegister(input.Register, input.Dir * input.Move);
                        }
                        break;
                    default:
                        break;
                }
            }

            // output all registers
            if (output)
            {
                int biggest = int.MinValue;
                foreach (Register register in registers)
                {
                    Console.WriteLine($"{register.Name} {register.Value}");
                    if (register.Value > biggest)
                    {
                        biggest = register.Value;
                    }
                }
                Console.WriteLine($"\nSolution Day 8 part 1: {biggest}");
            }
            return biggestRegisterValue;
        }
        
        public static void Part2()
        {
            int biggest = Part1(false);
            Console.WriteLine($"\nSolution Day 8 part 2: {biggest}");
        }

        private static void AddToRegister(string registerName, int add)
        {
            var query =
                from Register register in registers
                where register.Name == registerName
                select register;

            query.First().Value += add;
            if (query.First().Value > biggestRegisterValue)
            {
                biggestRegisterValue = query.First().Value;
            }
        }

        private static int GetValueOf(string registerName)
        {
            var query =
                from Register register in registers
                where register.Name == registerName
                select register;

            return query.First().Value;

        }

        private enum Condition
        {
            equals,
            notequals,
            greaterthan,
            lessthan,
            greateroreven,
            lessoreven
        }

        class Register
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Register(string name)
            {
                this.Name = name;
                this.Value = 0;
            }
        }

        class Input
        {
            public string Register { get; set; }
            public int Value { get; set; }
            public int Dir { get; set; }
            public int Move { get; set; }
            public string ConRegister { get; set; }
            public Condition ConOperator { get; set; }
            public int ConValue { get; set; }

            public Input(string line)
            {
                string[] parts = line.Split(' ');
                this.Value = 0;
                this.Register = parts[0];
                this.Dir = parts[1] == "inc" ? 1 : -1;
                this.Move = int.Parse(parts[2]);
                this.ConRegister = parts[4];
                switch (parts[5])
                {
                    case "==":
                        this.ConOperator = Condition.equals;
                        break;
                    case "!=":
                        this.ConOperator = Condition.notequals;
                        break;
                    case ">":
                        this.ConOperator = Condition.greaterthan;
                        break;
                    case "<":
                        this.ConOperator = Condition.lessthan;
                        break;
                    case ">=":
                        this.ConOperator = Condition.greateroreven;
                        break;
                    case "<=":
                        this.ConOperator = Condition.lessoreven;
                        break;
                    default:
                        break;
                }
                this.ConValue = int.Parse(parts[6]);

            }
        }
    }


}
