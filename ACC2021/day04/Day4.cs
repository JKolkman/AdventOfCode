using System;
using System.Collections.Generic;
using System.Linq;
using AdventCalendarCode.day4;

namespace AdventCalendarCode.day04
{
    public class Day4 : IDay
    {
        private readonly string[] _lines;
        private readonly List<Day4_Board> _boards = new List<Day4_Board>();

        public Day4()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day04\Day4-Input.txt");
            _lines = _lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        public void Run()
        {
            BothTasks();
        }

        private void BothTasks()
        {
            var timer = DateTime.UtcNow;
            var bingoNumbers = Array.ConvertAll(_lines[0].Split(","), int.Parse);
            var (i1, item3) = (-1, -1);
            var (i2, item4) = (-1, -1);
            for(var i = 1; i < _lines.Length; i+=5)
            {
                var buffer = new string[5];
                Array.Copy(_lines, i, buffer, 0, 5);
                _boards.Add(new Day4_Board(buffer));
            }
            
            foreach (var num in bingoNumbers)
            {
                foreach (var board in _boards)
                {
                    var (item1, item2) = board.AddNumber(num);
                    if (i1 == -1 && item1)
                    {
                        i1 = item2;
                        item3 = num;
                    }

                    if (!item1) continue;
                    i2 = item2;
                    item4 = num;
                }
            }
            Console.WriteLine($"04.X: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine($"(1) {i1 * item3}");
            //Console.Write("        ");
            //Console.WriteLine($"(2) {i2 * item4}");
        }
    }
}