using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day13
{
    public class Day13 : IDay
    {
        private readonly string[] _input;

        public Day13(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day13\Day13-Test-Input.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day13\Day13-Input.txt")
            };
        }

        public void Run()
        {
            var list = new List<(int, int)>();
            var instructions = new Queue<string>();
            foreach (var line in _input)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (line.StartsWith("fold along"))
                {
                    instructions.Enqueue(line);
                }
                else
                {
                    var split = line.Split(",");
                    list.Add((int.Parse(split[0]), int.Parse(split[1])));
                }
            }

            Task1(list, instructions);
        }

        private void Task1(List<(int, int)> list, Queue<string> instructions)
        {
            var firstRun = true;
            while (instructions.Count > 0)
            {
                var instruction = instructions.Dequeue();
                var pos = int.Parse(instruction.Split("=")[1]);
                var whichAxle = instruction.Split("=")[0].Last();
                var newList = new List<(int, int)>();

                foreach (var l in list)
                {
                    if (whichAxle == 'y')
                    {
                        if (l.Item2 < pos)
                        {
                            newList.Add(l);
                        }
                        else if (l.Item2 > pos)
                        {
                            var posDif = l.Item2 - pos;
                            var y = pos - posDif;
                            newList.Add((l.Item1, y));
                        }
                    }
                    else
                    {
                        if (l.Item1 < pos)
                        {
                            newList.Add(l);
                        }
                        else if (l.Item1 > pos)
                        {
                            var posDif = l.Item1 - pos;
                            var x = pos - posDif;
                            newList.Add((x, l.Item2));
                        }
                    }
                }

                list = newList;
                if (!firstRun) continue;
                Console.WriteLine($"(1) {list.Distinct().Count()}");
                firstRun = false;
            }

            var xHigh = list.Max(x => x.Item1) + 1;
            var yHigh = list.Max(x => x.Item2) + 1;

            for (int i = 0; i < xHigh; i++)
            {
                for (int j = 0; j < yHigh; j++)
                {
                    if (list.Contains((i,j)))
                    {
                        Console.Write(" #");
                    }
                    else
                    {
                        Console.Write(" .");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
