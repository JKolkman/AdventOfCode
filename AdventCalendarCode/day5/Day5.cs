using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCalendarCode.day5
{
    public class Day5
    {
        private string[] _lines;
        private List<(string, string)> _input;
        private int[,] grid;

        public Day5()
        {
            _input = new List<(string, string)>();
        }

        public void Run()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day5\Day5-Input.txt");

            foreach (var line in _lines)
            {
                var temp = line.Split(" -> ");
                _input.Add((temp[0], temp[1]));
            }

            Task1();
            Task2();
        }

        private void Task1()
        {
            grid = new int[999, 999];
            foreach (var (item1, item2) in _input)
            {
                var p1 = Array.ConvertAll(item1.Split(","), int.Parse);
                var p2 = Array.ConvertAll(item2.Split(","), int.Parse);

                var p1X = p1[0];
                var p1Y = p1[1];
                var p2X = p2[0];
                var p2Y = p2[1];

                if (p1X == p2X)
                {
                    int high; 
                    int low;
                    
                    if (p1Y > p2Y)
                    {
                        high = p1Y;
                        low = p2Y;
                    }
                    else
                    {
                        high = p2Y;
                        low = p1Y;
                    }

                    for (var i = low - 1; i < high; i++)
                    {
                        grid[p1X, i] += 1;
                    }
                } 
                else if (p1Y == p2Y)
                {
                    int high; 
                    int low;
                    
                    if (p1X > p2X)
                    {
                        high = p1X;
                        low = p2X;
                    }
                    else
                    {
                        high = p2X;
                        low = p1X;
                    }

                    for (var i = low - 1; i < high; i++)
                    {
                        grid[i, p1Y] += 1;
                    }
                }
            }

            var count = grid.Cast<int>().Count(num => num >= 2);

            Console.WriteLine($"Task 1: {count}");
        }

        private void Task2()
        {
            
            //DOESN'T WORK!!
            grid = new int[999, 999];
            foreach (var (item1, item2) in _input)
            {
                var p1 = Array.ConvertAll(item1.Split(","), int.Parse);
                var p2 = Array.ConvertAll(item2.Split(","), int.Parse);

                var p1X = p1[0];
                var p1Y = p1[1];
                var p2X = p2[0];
                var p2Y = p2[1];

                var differenceX = 0;
                var differenceY = 0;
                if (p1X > p2X)
                {
                    differenceX = p1X - p2X;
                }
                else
                {
                    differenceX = p2X - p1X;
                }

                if (p1Y > p2Y)
                {
                    differenceY = p1Y - p2Y;
                }
                else
                {
                    differenceY = p2Y - p1Y;
                }

                var xLow = 0;
                var yLow = 0;
                switch ((p1X >= p2X), (p1Y >= p2Y))
                {
                    case (true, true):
                        xLow = p2X;
                        yLow = p2Y;
                        break;
                    case (true, false):
                        xLow = p2X;
                        yLow = p1Y;
                        break;
                    case (false, false):
                        xLow = p1X;
                        yLow = p1Y;
                        break;
                    case (false, true):
                        xLow = p1X;
                        yLow = p2Y;
                        break;
                }

                if (differenceX == differenceY)
                {
                    for (var i = 0; i < differenceX - 1; i++)
                    {
                        grid[xLow + i, yLow + i] += 1;
                    }

                } else if (differenceX == 0)
                {
                    for (var i = 0; i < differenceY - 1; i++)
                    {
                        grid[p1X, yLow + i] += 1;
                    }
                } else if (differenceY == 0) 
                {
                    for (var i = 0; i < differenceX - 1; i++)
                    {
                        grid[xLow + i, yLow] += 1;
                    }
                }
            }
            
            var count = grid.Cast<int>().Count(num => num >= 2);

            Console.WriteLine($"Task 2: {count}");
        }
    }
}