using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day15
{
    public class Day15 : IDay
    {
        private readonly string[] _input;
        private static Node[,] _grid;

        public Day15(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day15\Day15-Test-Input.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day15\Day15-Input.txt")
            };
        }

        public void Run()
        {
            var time = DateTime.UtcNow;
            _grid = new Node[_input.Length, _input[0].Length];
            for (var i = 0; i < _input.Length; i++)
            {
                for (var j = 0; j < _input[i].Length; j++)
                {
                    var weight = int.Parse(_input[i].ToCharArray()[j].ToString());
                    _grid[i, j] = new Node(j, i, weight);
                }
            }
            
            var expandedGrid = new Node[_grid.GetLength(0) * 5, _grid.GetLength(1) * 5];
            for (var i = 0; i < _input.Length; i++)
            {
                for (var j = 0; j < _input[i].Length; j++)
                {
                    var gridSizeX = _input[i].Length;
                    var gridSizeY = _input.Length;
                    for (var k = 0; k < 5; k++)
                    {
                        var newX = j + k * gridSizeX;
                        for (var l = 0; l < 5; l++)
                        {
                            var input = int.Parse(_input[i][j].ToString());
                            input += k;
                            input += l;
                            if (input > 9)
                            {
                                input -= 9;
                            }

                            var newY = i + l * gridSizeY;
                            expandedGrid[newY, newX] = new Node(newX, newY, input);
                        }
                    }
                }
            }
            
            Console.Write(("15.1: "));
            Tasks();
            _grid = expandedGrid;
            Console.Write(("15.2: "));
            Tasks();
        }

        private static void Tasks()
        {
            var timer = DateTime.UtcNow;
            var queue = new Queue<(int, int)>();
            _grid[0, 0].InQueue = true;
            queue.Enqueue((0, 0));
            while (queue.TryDequeue(out var coords))
            {
                var n = _grid[coords.Item1, coords.Item2];
                n.Visited = true;
                n.InQueue = false;
                FindNeighbours(n).ForEach(x =>
                {
                    if (x.Visited|| x.InQueue)
                    {
                        if (x.Distance > x.Weight + n.Distance)
                        {
                            x.Distance = x.Weight + n.Distance;
                        }
                        if (n.Distance <= n.Weight + x.Distance) return;
                        n.Distance = n.Weight + x.Distance;
                    }
                    else
                    {
                        x.Distance = x.Weight + n.Distance;
                        x.InQueue = true;
                        queue.Enqueue((x.Y, x.X));
                    }
                });
            }

            var finalNode = _grid[_grid.GetUpperBound(0), _grid.GetUpperBound(1)];
            Console.WriteLine($"{(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine(finalNode.Distance + " : " + (DateTime.UtcNow - timer));
        }

        private static List<Node> FindNeighbours(Node node)
        {
            var neighbours = new List<Node>();

            if (node.X < _grid.GetLength(1) - 1)
            {
                neighbours.Add(_grid[node.Y, node.X + 1]);
            }

            if (node.Y < _grid.GetLength(0) - 1)
            {
                neighbours.Add(_grid[node.Y + 1, node.X]);
            }

            return neighbours;
        }
    }

    internal class Node
        {
            public int Distance;
            public readonly int Y;
            public readonly int X;
            public readonly int Weight;
            public bool InQueue;
            public bool Visited;

            public Node(int x, int y, int weight)
            {
                X = x;
                Y = y;
                Weight = weight;
                Distance = 0;
                InQueue = false;
                Visited = false;
            }
        }
}