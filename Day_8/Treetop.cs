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
        public static string path = @"D:\GitHub\AdventOfCode\Day_8\input.txt";
        public static string[] inputFile = File.ReadAllLines(path);
        public static List<string> lines = new List<string>(inputFile);

        public static bool flag = true;

        static int numberOfTreesInRow = lines[0].Count();

        static int numberOfTreesInColumn = lines.Count();

        static void Main(String[] args)
        {


            void Part1()
            {



                int numberOfTrees = numberOfTreesInColumn * 2 + numberOfTreesInRow * 2 - 4;



                for (int i = 1; i < lines.Count() - 1; i++)
                {
                    for (int j = 1; j < lines[i].Count() - 1; j++)
                    {
                        if (checkNorth(i, j) || checkSouth(i, j) || checkEast(i, j) || checkWest(i, j)) numberOfTrees += 1;
                    }
                }

                System.Console.WriteLine(numberOfTrees);
            }

            void Part2() { }

            Part1();
        }


        static bool checkNorth(int i, int j)
        {
            for (int rowIndex = i - 1; rowIndex >= 0; rowIndex--)
            {
                if (lines[rowIndex][j] >= lines[i][j]) return false;
            }
            return true;
        }

        static bool checkSouth(int i, int j)
        {
            for (int rowIndex = i + 1; rowIndex <= numberOfTreesInColumn - 1; rowIndex++)
            {
                if (lines[rowIndex][j] >= lines[i][j]) return false;
            }
            return true;
        }

        static bool checkEast(int i, int j)
        {
            for (int colIndex = j + 1; colIndex < numberOfTreesInRow; colIndex++)
            {
                if (lines[i][colIndex] >= lines[i][j]) return false;
            }
            return true;
        }

        static bool checkWest(int i, int j)
        {
            for (int colIndex = j - 1; colIndex >= 0; colIndex--)
            {
                if (lines[i][colIndex] >= lines[i][j]) return false;
            }
            return true;
        }
    }
}
