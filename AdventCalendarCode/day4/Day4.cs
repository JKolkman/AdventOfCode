using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day4
{
    public class Day4
    {
        private string[] _lines;
        private List<Day4_Board> _boards = new List<Day4_Board>();
        public void Run()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day4\Day4-Input.txt");
            _lines = _lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            Console.WriteLine("-- Day 4--");
            Task1();
        }

        private void Task1()
        {
            var bingoNumbers = Array.ConvertAll(_lines[0].Split(","), int.Parse);
            (int, int) firstWin = (-1, -1);
            (int, int) lastWin = (-1, -1);
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
                    var result = board.AddNumber(num);
                    if (firstWin.Item1 == -1 && result.Item1)
                    {
                        firstWin.Item1 = result.Item2;
                        firstWin.Item2 = num;
                    }

                    if (result.Item1)
                    {
                        lastWin.Item1 = result.Item2;
                        lastWin.Item2 = num;
                    }
                }
            }
            Console.WriteLine($"Task 1: {firstWin.Item1 * firstWin.Item2}");
            Console.WriteLine($"Task 2: {lastWin.Item1 * lastWin.Item2}");
        }
    }
}