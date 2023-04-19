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
            string path = @"D:\GitHub\AdventOfCode\Day_3\input.txt";
            var inputFile = File.ReadAllLines(path);
            var lines = new List<string>(inputFile);



            void Part1()
            {
                decimal sum = 0;

                char temp;
                foreach (string line in lines)
                {
                    int splitIndex = line.Length / 2;

                    string firstPart = line.Substring(0, splitIndex);
                    string secondPart = line.Substring(splitIndex);

                    string repString = sameString(firstPart, secondPart);
                    char repChar = Convert.ToChar(repString);
                    if (isBig(repChar) == true)
                    {
                        decimal repCharDec = repChar;
                        sum += repCharDec - 38;
                    }
                    else if (isSmall(repChar) == true)
                    {
                        decimal repCharDec = repChar;
                        sum += repCharDec - 96;
                    }
                }
                System.Console.WriteLine(sum);
            }
            void Part2()
            {
                char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                int sum = 0;

                int lineCount = 0;
                string[] group = new string[3];

                foreach (string line in lines)
                {
                    if (lineCount < 3)
                    {
                        group[lineCount] = line;
                        lineCount++;
                    }

                    if (lineCount == 3)
                    {

                        List<char>? charMatches = new List<char>();
                        foreach (char c in group[1])
                        {
                            if (group[0].Contains(c))
                            {
                                charMatches.Add(c);
                            }
                        }
                        foreach (char c in group[2])
                        {
                            if (charMatches.Contains(c))
                            {
                                charMatches.Add(c);
                                sum += Array.IndexOf(characters, c) + 1;
                                break;
                            }
                        }
                        group = new string[3];
                        lineCount = 0;
                    }

                }
                System.Console.WriteLine(sum);
            }
            Part2();
        }



        public static string sameString(string firstPart, string secondPart)
        {
            char temp;
            foreach (char element in firstPart)
            {
                temp = element;
                foreach (char element2 in secondPart)
                {
                    if (temp == element2)
                    {
                        return Convert.ToString(temp);
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            return "brak";
        }

        public static Boolean isSmall(char c)
        {
            char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
            foreach (var b in az)
            {
                if (c == b)
                {
                    return true;
                }
                else if (c != b)
                {
                    continue;
                }
                else return false;
            }
            return false;
        }

        public static Boolean isBig(char c)
        {
            char[] az = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
            foreach (var b in az)
            {
                if (c == b)
                {
                    return true;
                }
                else if (c != b)
                {
                    continue;
                }
                else return false;
            }
            return false;
        }
    }
}