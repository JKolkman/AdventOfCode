using System;
using System.Collections.Generic;

namespace ACC2020.day01
{
    public class Day1 : IDay
    {
        public void Run(bool testRun)
        {
            var input = Array.ConvertAll(System.IO.File.ReadAllLines(testRun switch
            {
                true => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day01\d1-test-input.txt",
                false => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day01\d1-input.txt"
            }), int.Parse);
            
            Console.WriteLine("D1");
            Tasks(input);
        }

        private static void Tasks(int[] input)
        {
            var hashSet = new HashSet<int>(input);
            foreach (var t in input)
            {
                if (!hashSet.Contains(2020 - t)) continue;
                Console.WriteLine("t1: " + (2020-t) * t);
                break;
            }

            foreach (var n1 in input)
            {
                foreach (var n2 in input)
                {
                    if (!hashSet.Contains(2020 - n1 - n2)) continue;
                    Console.WriteLine("t2: " + (2020-n1-n2) * n1 * n2);
                    goto End;
                }
            }
            End : ;
        }
    }
}