using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day11
{
    public class Day11 : IDay
    {
        private readonly string[] _input;

        public Day11(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day11\Day11-Test-Input.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day11\Day11-Input.txt")
            };
        }
        public void Run()
        {
            Console.Write("Day 11: ");
            Task1();
        }

        private void Task1()
        {
            var temp = Array.ConvertAll(_input, s => s.ToCharArray());
            var field = Array.ConvertAll(temp, s => Array.ConvertAll(s, c => int.Parse(c.ToString())));
            var flashCount = 0;
            var flashCountTask1 = 0;
            var allFlashed = false;
            var run = 0;
            while(!allFlashed){
                var somethingChanged = true;
                if (run == 100)
                {
                    flashCountTask1 = flashCount;
                }
                for (var j = 0; j < field.Length; j++)
                {
                    for (int k = 0; k < field[j].Length; k++)
                    {
                        field[j][k]++;
                    }
                }

                while (somethingChanged)
                {
                    somethingChanged = false;
                    for (var i = 0; i < field.Length; i++)
                    {
                        for (var j = 0; j < field[i].Length; j++)
                        {
                            switch (field[i][j])
                            {
                                case 0:
                                    continue;
                                case > 9:
                                {
                                    field[i][j] = 0;
                                    flashCount++;
                                    somethingChanged = true;
                                    for (var x = i - 1; x <= i + 1; x++)
                                    {
                                        for (var y = j - 1; y <= j + 1; y++)
                                        {
                                            if (x == i && y == j) continue; // skip the position where your 2 is
                                            if (x < 0 || y < 0 || x >= field.Length || y >= field[i].Length) continue;
                                            if (field[x][y] == 0) continue;
                                            field[x][y]++;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                run++;
                if (field.ToList().TrueForAll(f => f.ToList().TrueForAll(l => l == 0)))
                {
                    allFlashed = true;
                }
            }
            Console.WriteLine($"(1) {flashCountTask1}");
            Console.WriteLine($"(2) {run}");
        }
    }
}