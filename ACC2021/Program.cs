using System;
using System.Collections.Generic;
using AdventCalendarCode.day13;
using AdventCalendarCode.day14;

namespace AdventCalendarCode
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Test run? y/n");
            var test = Console.ReadKey().Key switch
            {
                ConsoleKey.Y => true,
                ConsoleKey.N => false,
                _ => true,
            };

            var days = new List<IDay>
            {
                //new Day1(),
                //new Day2(),
                //new Day3(),
                //new Day4(),
                //new Day5(),
                //new Day6(),
                //new Day7(),
                //new Day8(test),
                //new Day9(test),
                //new Day10(test),
                //new Day11(test),

                new Day13(test),
                //new Day14(test)
            };

            foreach (var day in days) day.Run();
        }
    }
}