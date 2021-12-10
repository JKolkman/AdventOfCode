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
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day05\Day5-Input.txt");

            foreach (var line in _lines)
            {
                var temp = line.Split(" -> ");
                _input.Add((temp[0], temp[1]));
            }
            Console.Write("Day 05: ");
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

                    for (var i = low ; i <= high; i++)
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

                    for (var i = low; i <= high; i++)
                    {
                        grid[i, p1Y] += 1;
                    }
                }
            }

            var count = grid.Cast<int>().Count(num => num >= 2);

            Console.WriteLine($"(1) {count}");
        }

        private void Task2()
        {
            
            //DOESN'T WORK!!
            grid = new int[999, 999];
            foreach (var (item1, item2) in _input)
            {
                var p1 = Array.ConvertAll(item1.Split(","), int.Parse);
                var p2 = Array.ConvertAll(item2.Split(","), int.Parse);

                if (p1 == p2) { }
                else if (p1[0] == p2[0])
                {
                    var diff = p1[1] > p2[1] ? p1[1] - p2[1] : p2[1] - p1[1];

                    for (var i = 0; i <= diff; i++)
                    {
                        var yPos = p1[1] > p2[1] ? p1[1] - i : p1[1] + i;
                        grid[p1[0], yPos] += 1;
                    }
                }
                else if (p1[1] == p2[1])
                {
                    var diff = p1[0] > p2[0] ? p1[0] - p2[0] : p2[0] - p1[0];

                    for (var i = 0; i <= diff; i++)
                    {
                        var xPos = p1[0] > p2[0] ? p1[0] - i : p1[0] + i;
                        grid[xPos, p1[0]] += 1;
                    }
                }
                else 
                {
                    var diff = p1[0] > p2[0] ? p1[0] - p2[0] : p2[0] - p1[0];
                    for (var i = 0; i <= diff; i++)
                    {
                        var xPos = p1[0] > p2[0] ? p1[0] - i : p1[0] + i;
                        var yPos = p1[1] > p2[1] ? p1[1] - i : p1[1] + i;
                        grid[xPos, yPos] += 1;
                    }
                }
                
                
            }
            var count = grid.Cast<int>().Count(num => num >= 2);
            Console.Write("        ");
            Console.WriteLine($"(2) {count}");
        }
    }
}