using System;
using System.Linq;

namespace AdventCalendarCode.day01
{
    internal class Day1 : IDay
    {
        private readonly int[] _numbers;

        public Day1()
        {
            var lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day01\Day1-Input.txt");
            _numbers = Array.ConvertAll(lines, int.Parse);
        }

        public void Run()
        {
            Task1();
            Task2();
        }

        private void Task1()
        {
            var timer = DateTime.UtcNow;
            var counter = 0;
            for (var i = 1; i < _numbers.Length; i++)
            {
                if (_numbers[i] > _numbers[i - 1])
                {
                    counter++;
                }
            }

            Console.WriteLine($"01.1: {(DateTime.UtcNow - timer).TotalMilliseconds}ms ");
            //Console.WriteLine($"(1) {counter}");
        }

        private void Task2()
        {
            var timer = DateTime.UtcNow;
            var counter = 0;
            for (var i = 3; i < _numbers.Length; i++)
            {
                var previousSet = _numbers.Skip(i - 3).Take(3);
                var currentSet = _numbers.Skip(i - 2).Take(3);

                if (previousSet.Sum() < currentSet.Sum())
                {
                    counter++;
                }
            }

            Console.WriteLine($"01.2: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine($"        (2) {counter}");
        }
    }
}