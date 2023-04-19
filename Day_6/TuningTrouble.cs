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
        static void Main(String[] args)
        {
            string path = @"D:\GitHub\AdventOfCode\Day_6\input.txt";
            string[] inputFile = File.ReadAllLines(path);
            List<string> lines = new List<string>(inputFile);

            string text = lines[0].ToString();

            char[] characters = text.ToCharArray();

            int output = 0;

            void Part1()
            {
                for (int i = 0; i < characters.Length - 3; i++)
                {
                    ArraySegment<char> arraySlice = new ArraySegment<char>(characters, i, 4);

                    if (!isContainDuplicates(arraySlice))
                    {
                        output = i + 4;
                        break;
                    }
                }

                System.Console.WriteLine(output);
            }

            void Part2()
            {
                for (int i = 0; i < characters.Length - 13; i++)
                {
                    ArraySegment<char> arraySlice = new ArraySegment<char>(characters, i, 14);

                    if (!isContainDuplicates(arraySlice))
                    {
                        output = i + 14;
                        break;
                    }
                }

                System.Console.WriteLine(output);
            }

            Part2();
        }

        public static bool isContainDuplicates(ArraySegment<char> arraySlice)
        {
            return arraySlice.GroupBy(x => x).Any(g => g.Count() > 1);
        }
    }
}