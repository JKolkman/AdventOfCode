using System;
using System.Linq;

namespace AdventCalendarCode.day1
{
    internal class Day1
    {
        private int[] _numbers;
        public Day1()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day1\Day1-Input.txt");
            _numbers = Array.ConvertAll(lines, int.Parse);
            
            Console.WriteLine("--Day 1--");
            Task1();
            Task2();
        }
        private void Task1()
        {
            var counter = 0;
            for(var i = 1; i < _numbers.Length; i++)
            {
                if (_numbers[i] > _numbers[i-1])
                {
                    counter++;
                }
            }
            Console.WriteLine($"Task 1: {counter}");
        }
        private void Task2()
        {
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
            Console.WriteLine($"Task 2: {counter}\n");
        }
    }
}