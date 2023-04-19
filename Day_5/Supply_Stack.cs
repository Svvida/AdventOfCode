using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdventOfCode

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\GitHub\AdventOfCode\Day_5\input.txt";
            var inputFile = File.ReadAllLines(path);
            var lines = new List<string>(inputFile);

            /*
            [N]     [C]                 [Q]    
            [W]     [J] [L]             [J] [V]
            [F]     [N] [D]     [L]     [S] [W]
            [R] [S] [F] [G]     [R]     [V] [Z]
            [Z] [G] [Q] [C]     [W] [C] [F] [G]
            [S] [Q] [V] [P] [S] [F] [D] [R] [S]
            [M] [P] [R] [Z] [P] [D] [N] [N] [M]
            [D] [W] [W] [F] [T] [H] [Z] [W] [R]
            1   2   3   4   5   6   7   8   9 


                [D]    
            [N] [C]    
            [Z] [M] [P]
            1   2   3 

            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            */
            //declarating variables

            // List<List<string>> Stacks2 = new List<List<string>>()
            // {
            //     new List<string> { "Z", "N" },
            //     new List<string> { "M", "C", "D" },
            //     new List<string> { "P" }
            // };

            List<List<string>> Stacks = new List<List<string>>
                {
                    new List<string>{"D","M","S","Z","R","F","W","N"},
                    new List<string>{"W","P","Q","G","S"},
                    new List<string>{"W","R","V","Q","F","N","J","C"},
                    new List<string>{"F","Z","P","C","G","D","L"},
                    new List<string>{"T","P","S"},
                    new List<string>{"H","D","F","W","R","L"},
                    new List<string>{"Z","N","D","C"},
                    new List<string>{"W","N","R","F","V","S","J","Q"},
                    new List<string>{"R","M","S","G","Z","W","V"}
                };


            void Part1()
            {

                foreach (var item in inputFile)
                {
                    string[] lineParts = item.Split(" ");

                    int numberOfCrates = int.Parse(lineParts[1]);

                    int stackNumber = int.Parse(lineParts[3]);

                    int toStackNumber = int.Parse(lineParts[5]);

                    for (int i = numberOfCrates; i > 0; i--)
                    {
                        string crateToMove = Stacks[stackNumber - 1][Stacks[stackNumber - 1].Count - 1];

                        Stacks[toStackNumber - 1].Add(crateToMove);

                        Stacks[stackNumber - 1].RemoveAt(Stacks[stackNumber - 1].Count - 1);
                    }
                }
                foreach (var stack in Stacks)
                {
                    foreach (var character in stack)
                    {
                        System.Console.Write(character);
                    }
                    System.Console.WriteLine();
                }



            }

            void Part2()
            {
                foreach (var item in inputFile)
                {
                    string[] lineParts = item.Split(" ");

                    int numberOfCrates = int.Parse(lineParts[1]);

                    int stackNumber = int.Parse(lineParts[3]);

                    int toStackNumber = int.Parse(lineParts[5]);

                    for (int i = numberOfCrates; i > 0; i--)
                    {

                        string crateToMove = Stacks[stackNumber - 1][Stacks[stackNumber - 1].Count - i];

                        Stacks[toStackNumber - 1].Add(crateToMove);

                        Stacks[stackNumber - 1].RemoveAt(Stacks[stackNumber - 1].Count - i);
                    }
                }
                foreach (var stack in Stacks)
                {
                    foreach (var character in stack)
                    {
                        System.Console.Write(character);
                    }
                    System.Console.WriteLine();
                }
            }

            Part2();
        }
    }
}