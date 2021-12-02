using System;
using System.Linq;

namespace AdventCalendarCode.day1
{
    internal class Day1
    {
        private int[] _numbers;
        public void Run()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day1\Day1-Input.txt");
            _numbers = Array.ConvertAll(lines, int.Parse);
            
            Console.WriteLine("Results of Day 1");
            Console.WriteLine(Task1());
            Console.WriteLine(Task2());
            Console.WriteLine();
        }
        private string Task1()
        {
            var counter = 0;
            for(var i = 1; i < _numbers.Length; i++)
            {
                if (_numbers[i] > _numbers[i-1])
                {
                    counter++;
                }
            }
            return $"The depth increases {counter} times.";
        }
        private string Task2()
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
            return $"The depth per set of 3 increases {counter} times";
        }
    }
}