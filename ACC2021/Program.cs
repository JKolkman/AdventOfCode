using System;
using System.Collections.Generic;
using System.Linq;
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
using AdventCalendarCode.day12;
using AdventCalendarCode.day13;
using AdventCalendarCode.day14;
using AdventCalendarCode.day15;
using AdventCalendarCode.day16;
using AdventCalendarCode.day17;
using AdventCalendarCode.day2;

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
            Console.Clear();
            Console.WriteLine("Run all(a) or just last(l)");
            var all = Console.ReadKey().Key == ConsoleKey.A;

            var days = new List<IDay>
            {
                new Day1(),
                new Day2(),
                new Day3(),
                new Day4(),
                new Day5(),
                new Day6(),
                new Day7(),
                new Day8(test),
                new Day9(test),
                new Day10(test),
                new Day11(test),
                new Day12(test),
                new Day13(test),
                new Day14(test),
                new Day15(test),
                //new Day16(test)
                new Day17(test)
            };
            Console.Clear();
            Console.WriteLine("All days have been Generated, Executing code now: ");
            var colorSwitch = false;

            if (all)
            {
                foreach (var day in days)
                {
                    Console.ForegroundColor = colorSwitch ? ConsoleColor.DarkCyan : ConsoleColor.Gray;
                    day.Run();
                    colorSwitch = !colorSwitch;
                }
            }
            else
            {
                days.Last().Run();
            }
        }
    }
}