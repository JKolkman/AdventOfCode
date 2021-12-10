using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day09
{
    public class Day9 : IDay
    {
        private readonly int[,] _field;
        private readonly List<Point> _lowPoints;

        public Day9(bool test)
        {
            var input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day09\Day9-TestInput.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day09\Day9-Input.txt")
            };
            _field = new int[input.Length, input[0].ToCharArray().Length];
            _lowPoints = new List<Point>();

            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].ToCharArray().Length; x++)
                {
                    _field[y, x] = int.Parse(input[y].ToCharArray()[x].ToString());
                }
            }
        }

        public void Run()
        {
            Console.Write("Day 09: ");
            Task1();
            Task2();
        }
        
        private void Task1()
        {
            var total = 0;
            for (var y = 0; y < _field.GetLength(0); y++)
            {
                for (var x = 0; x < _field.GetLength(1); x++)
                {
                    var neighbours = FindNeighbours(x, y);
                    if (!neighbours.All(n => n.Value > _field[y, x])) continue;
                    total += _field[y, x] + 1;
                    _lowPoints.Add(new Point(_field[y, x], x, y));
                }
            }

            Console.WriteLine($"(1) {total}");
        }

        private void Task2()
        {
            var basins = new List<int>();
            foreach (var point in _lowPoints)
            {
                var stack = new Stack<Point>();
                var basin = new List<Point> {point};
                stack.Push(point);

                while (stack.Count > 0)
                {
                    var cur = stack.Pop();
                    var neighbours = FindNeighbours(cur.X, cur.Y);

                    foreach (var neighbour in neighbours)
                    {
                        var alreadyThere = false;
                        foreach (var p in basin.Where(p => p.X == neighbour.X && p.Y == neighbour.Y))
                        {
                            alreadyThere = true;
                        }

                        if (alreadyThere || neighbour.Value <= _field[cur.Y, cur.X] || neighbour.Value == 9) continue;
                        stack.Push(neighbour);
                        basin.Add(neighbour);
                    }
                }
                basins.Add(basin.Count);
            }

            basins.Sort();
            basins.Reverse();

            Console.Write("        ");
            Console.WriteLine($"(2) {basins[0] * basins[1] * basins[2]}");
            
        }

        private IEnumerable<Point> FindNeighbours(int x, int y)
        {
            var neighbours = new List<Point>();

            if (x > 0)
            {
                neighbours.Add(new Point(_field[y, x - 1], x - 1, y));
            }

            if (y > 0)
            {
                neighbours.Add(new Point(_field[y - 1, x], x, y - 1));
            }

            if (x < _field.GetLength(1) - 1)
            {
                neighbours.Add(new Point(_field[y, x + 1], x + 1, y));
            }

            if (y < _field.GetLength(0) - 1)
            {
                neighbours.Add(new Point(_field[y + 1, x], x, y + 1));
            }

            return neighbours.ToArray();
        }
    }

    internal class Point
    {
        public readonly int Value;
        public readonly int X;
        public readonly int Y;
        
        public Point(int value, int x, int y)
        {
            this.Value = value;
            this.X = x;
            this.Y = y;
        }
    }
}