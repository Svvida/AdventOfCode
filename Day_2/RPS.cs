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
            string path = @"D:\GitHub\AdventOfCode\Day_2\input.txt";
            var inputFile = File.ReadAllLines(path);
            var lines = new List<string>(inputFile);

            void Part1()
            {
                var inputScore = new Dictionary<string, int>(){
                    {"X",1},
                    {"Y",2},
                    {"Z",3}
                };

                foreach (var item in inputScore)
                {
                    System.Console.WriteLine(item);
                }

                int score = 0;

                foreach (var line in lines)
                {
                    var lineChoices = line.Split(" ");
                    var opponent = lineChoices[0];
                    var myChoice = lineChoices[1];
                    if (winCase(opponent, myChoice) == true)
                    {
                        score += 6 + inputScore[myChoice];
                    }
                    else if (drawCase(opponent, myChoice) == true)
                    {
                        score += 3 + inputScore[myChoice];
                    }
                    else
                    {
                        score += inputScore[myChoice];
                    }
                }
                System.Console.WriteLine(score);

            }

            void Part2()
            {
                var inputScore = new Dictionary<string, int>(){
                    {"X",1},
                    {"Y",2},
                    {"Z",3}
                };

                int score = 0;

                foreach (var line in lines)
                {
                    var lineChoices = line.Split(" ");
                    var opponent = lineChoices[0];
                    var myChoice = lineChoices[1];
                    if (myChoice == "X")
                    {
                        myChoice = myLose(myChoice, opponent);
                        score += inputScore[myChoice];
                    }
                    else if (myChoice == "Y")
                    {
                        myChoice = myDraw(myChoice, opponent);
                        score += 3 + inputScore[myChoice];
                    }
                    else if (myChoice == "Z")
                    {
                        myChoice = myWin(myChoice, opponent);
                        score += 6 + inputScore[myChoice];
                    }
                }
                System.Console.WriteLine(score);
            }
            Part2();
        }

        //Part 1
        public static Boolean winCase(string opponent, string myChoice)
        {
            if (opponent == "A" && myChoice == "Y" || opponent == "B" && myChoice == "Z" || opponent == "C" && myChoice == "X") return true;
            else return false;
        }
        public static Boolean drawCase(string opponent, string myChoice)
        {
            if (opponent == "A" && myChoice == "X" || opponent == "B" && myChoice == "Y" || opponent == "C" && myChoice == "Z") return true;
            else return false;
        }

        //Part 2
        public static string myLose(string myChoice, string opponent)
        {
            if (myChoice == "X" && opponent == "A")
            {
                myChoice = "Z";
                return myChoice;
            }
            else if (myChoice == "X" && opponent == "B")
            {
                myChoice = "X";
                return myChoice;
            }
            else if (myChoice == "X" && opponent == "C")
            {
                myChoice = "Y";
                return myChoice;
            }
            return "Błąd";
        }
        public static string myWin(string myChoice, string opponent)
        {
            if (myChoice == "Z" && opponent == "A")
            {
                myChoice = "Y";
                return myChoice;
            }
            else if (myChoice == "Z" && opponent == "B")
            {
                myChoice = "Z";
                return myChoice;
            }
            else if (myChoice == "Z" && opponent == "C")
            {
                myChoice = "X";
                return myChoice;
            }
            return "Błąd";
        }
        public static string myDraw(string myChoice, string opponent)
        {
            if (myChoice == "Y" && opponent == "A")
            {
                myChoice = "X";
                return myChoice;
            }
            else if (myChoice == "Y" && opponent == "B")
            {
                myChoice = "Y";
                return myChoice;
            }
            else if (myChoice == "Y" && opponent == "C")
            {
                myChoice = "Z";
                return myChoice;
            }
            return "Błąd";
        }
    }
}