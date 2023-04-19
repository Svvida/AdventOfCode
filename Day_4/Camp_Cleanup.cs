using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\GitHub\AdventOfCode\Day_4\input.txt";
            var inputFile = File.ReadAllLines(path);
            var lines = new List<string>(inputFile);
            //declarating variables
            int counter = 0;
            int count = 0;
            int intFirstPart;
            int intSecondPart;
            int intThirdPart;
            int intFourthPart;

            void Part1()
            {
                foreach (string line in lines)
                {
                    splitLine(line, out intFirstPart, out intSecondPart, out intThirdPart, out intFourthPart);
                    //checking if one pair part fully contain another 
                    if (isContainFully(intFirstPart, intSecondPart, intThirdPart, intFourthPart) == true)
                    {
                        counter += 1;
                    }
                }
                System.Console.WriteLine(counter);
            }

            void Part2()
            {
                foreach (string line in lines)
                {
                    splitLine(line, out intFirstPart, out intSecondPart, out intThirdPart, out intFourthPart);

                    //checking if any part contain another
                    if (isContain(intFirstPart, intSecondPart, intThirdPart, intFourthPart) == true)
                    {
                        counter += 1;
                    }
                }
                System.Console.WriteLine(counter);
            }
            Part2();
        }
        //Method to split line
        public static void splitLine(string line, out int intFirstPart, out int intSecondPart, out int intThirdPart, out int intFourthPart)
        {
            string[] parts = line.Split(',', '-');
            intFirstPart = Convert.ToInt16(parts[0]);
            intSecondPart = Convert.ToInt16(parts[1]);
            intThirdPart = Convert.ToInt16(parts[2]);
            intFourthPart = Convert.ToInt16(parts[3]);
        }

        public static Boolean isContainFully(int intFirstPart, int intSecondPart, int intThirdPart, int intFourthPart)
        {
            if (intFirstPart <= intThirdPart && intSecondPart >= intFourthPart)
            {
                return true;
            }
            else if (intFirstPart >= intThirdPart && intSecondPart <= intFourthPart)
            {
                return true;
            }
            else return false;
        }

        public static Boolean isContain(int intFirstPart, int intSecondPart, int intThirdPart, int intFourthPart)
        {
            if (intFirstPart <= intThirdPart && intThirdPart <= intSecondPart) return true;
            else if (intFourthPart <= intSecondPart && intFourthPart >= intFirstPart) return true;
            else if (intSecondPart >= intThirdPart && intSecondPart <= intFourthPart) return true;
            else if (intFirstPart >= intThirdPart && intFirstPart <= intFourthPart) return true;
            else return false;
        }
    }
}