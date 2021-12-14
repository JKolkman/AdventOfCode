using System.Collections.Generic;
using AdventCalendarCode.day14;

namespace AdventCalendarCode
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const bool test = false;
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


                new Day14(test)
            };

            foreach (var day in days) day.Run();
        }
    }
}