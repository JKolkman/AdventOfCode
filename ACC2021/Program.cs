using System.Collections.Generic;
using AdventCalendarCode.day01;
using AdventCalendarCode.day03;
using AdventCalendarCode.day04;
using AdventCalendarCode.day05;
using AdventCalendarCode.day06;
using AdventCalendarCode.day07;
using AdventCalendarCode.day08;
using AdventCalendarCode.day09;
using AdventCalendarCode.day10;
using AdventCalendarCode.day11;
using AdventCalendarCode.day2;
using AdventCalendarCode.day4;

namespace AdventCalendarCode
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const bool test = false;
            var days = new List<IDay>()
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
                new Day11(test)
            };

            foreach (var day in days)
            {
                day.Run();
            }
        }
    }
}