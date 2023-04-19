using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AdventOfCode

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\GitHub\AdventOfCode\Day_1\supplies.txt";

            int elfNumber = 1;
            int intLine;
            int sumOfFood = 0;
            int mostFood = 0;
            int elfWithMostFood = 0;

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {

                if (line.Length != 0)
                {
                    intLine = int.Parse(line);
                    sumOfFood += intLine;
                }
                else if (line.Length == 0)
                {
                    int tempFood = sumOfFood;
                    if (tempFood > mostFood)
                    {
                        mostFood = tempFood;
                        elfWithMostFood = elfNumber;

                    }

                    elfNumber += 1;
                    sumOfFood = 0;
                }

            }
            System.Console.WriteLine($"Elf with most food is elf number {elfWithMostFood} and he has {mostFood}");
        }
    }
}