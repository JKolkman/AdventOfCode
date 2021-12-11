using System;
using System.Collections.Generic;
using System.Linq;

namespace ACC2020.day02
{
    public class Day2 : IDay
    {
        public void Run(bool testRun)
        {
            var input = System.IO.File.ReadAllLines(testRun switch
            {
                true => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day02\d2-test-input.txt",
                false => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day02\d2-input.txt"
            });
            
            Console.WriteLine("D2");
            Tasks(input);
        }

        private static void Tasks(IEnumerable<string> input)
        {
            var validPasswordsT1 = 0;
            var validPasswordsT2 = 0;
            foreach (var line in input)
            {
                var split = line.Split(":");
                var rule = split[0].Trim().Split(" ");
                var (min, max) = (int.Parse(rule[0].Split("-")[0]), int.Parse(rule[0].Split("-")[1]));
                var passwordArray = Array.ConvertAll(split[1].Trim().ToCharArray(), s => s.ToString());
                
                //TASK 1
                var totalCount = passwordArray.Count(c => c.Equals(rule[1]));
                if (totalCount >= min && totalCount <= max)
                {
                    validPasswordsT1++;
                }
                
                //TASK 2
                var correctMin = passwordArray[min - 1] == rule[1];
                var correctMax = passwordArray[max - 1] == rule[1];

                switch (correctMin, correctMax)
                {
                    case (true, false):
                    case (false, true):
                        validPasswordsT2++;
                        break;
                }
            }
            
            Console.WriteLine($"t1: {validPasswordsT1}");
            Console.WriteLine($"t2: {validPasswordsT2}");
        }
    }
}