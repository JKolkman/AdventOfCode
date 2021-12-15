using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day15
{
    public class Day15 : IDay
    {
        private string[] _input;
        private Node[,] grid;

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
            grid = new Node[_input.Length, _input[0].Length];
            for (var i = 0; i < _input.Length; i++)
            {
                for (var j = 0; j < _input[i].Length; j++)
                {
                    var weight = int.Parse(_input[i].ToCharArray()[j].ToString());
                    grid[i, j] = new Node(j, i, weight);
                }
            }

            var expandedGrid = new Node[grid.GetLength(0) * 5, grid.GetLength(1) * 5];
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
            Console.WriteLine();
            Console.Write(("(1) "));
            Tasks();
            grid = expandedGrid;
            Console.Write(("(2) "));
            Tasks();
        }

        private void Tasks()
        {
            var time = DateTime.UtcNow;
            grid[0, 0].Distance = 0;
            var queue = new Queue<(int, int)>();
            var visited = new HashSet<(int, int)>();

            var nodeDict = new Dictionary<(int, int), Node>
            {
                [(0, 0)] = grid[0, 0]
            };
            queue.Enqueue((0, 0));
            while (queue.TryDequeue(out var coords))
            {
                var n = nodeDict[coords];
                visited.Add(coords);
                nodeDict.Remove(coords);

                FindNeighbours(n).ToList().ForEach(x =>
                {
                    var nCoord = (x.Y, x.X);
                    if (visited.Contains(nCoord) || nodeDict.ContainsKey(nCoord))
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
                        nodeDict.Add((x.Y, x.X), x);
                        queue.Enqueue((x.Y, x.X));
                    }
                });
            }

            var finalNode = grid[grid.GetUpperBound(0), grid.GetUpperBound(1)];
            Console.WriteLine(finalNode.Distance + " : " + (DateTime.UtcNow - time));
            //PrintGrid(finalNode.VisitedNodes);
        }

        private IEnumerable<Node> FindNeighbours(Node node)
        {
            var x = node.X;
            var y = node.Y;
            var neighbours = new List<Node>();

            if (x < grid.GetLength(1) - 1)
            {
                neighbours.Add(grid[y, x + 1]);
            }

            if (y < grid.GetLength(0) - 1)
            {
                neighbours.Add(grid[y + 1, x]);
            }

            return neighbours;
        }

        private void PrintGrid(System.Collections.Generic.ICollection<Node> list, Node[,] customGrid = null)
        {
            customGrid ??= grid;

            var y = customGrid.GetLength(0);
            var x = customGrid.GetLength(1);
            Console.WriteLine();
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    Console.ForegroundColor =
                        list.Contains(customGrid[i, j]) ? ConsoleColor.Cyan : ConsoleColor.DarkGray;

                    Console.Write($" {customGrid[i, j].Weight}");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }

    internal class Node
    {
        public int Distance { get; set; }
        public readonly int Y;
        public readonly int X;

        public readonly int Weight;
        //public List<Node> VisitedNodes;

        public Node(int x, int y, int weight)
        {
            X = x;
            Y = y;
            Weight = weight;
            Distance = int.MaxValue / 2;
            //VisitedNodes = new List<Node>();
        }
    }
}