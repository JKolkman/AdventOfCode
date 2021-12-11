using System;
using System.Collections.Generic;
using System.Linq;

namespace ACC2020.day03
{
    public class Day3 : IDay
    {
        public void Run(bool testRun)
        {
            var input = Array.ConvertAll(System.IO.File.ReadAllLines(testRun switch
            {
                true => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day03\d3-test-input.txt",
                false => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day03\d3-input.txt"
            }), s => s.ToCharArray());

            var list = input.ToList().ConvertAll(a => a.ToList());
            Console.WriteLine("D3");
            Tasks(list);
        }

        private void Tasks(List<List<char>> input)
        {
            var set1 = HowManyTreesHit(input, 1, 1);
            var set2 = HowManyTreesHit(input, 3, 1);
            var set3 = HowManyTreesHit(input, 5, 1);
            var set4 = HowManyTreesHit(input, 7, 1);
            var set5 = HowManyTreesHit(input, 1, 2);
            
            
            Console.WriteLine($"t1: {set2}");
            Console.WriteLine($"t2: {set1 * set2 * set3 * set4 * set5}");
        }

        private long HowManyTreesHit(List<List<char>> input, int xStep, int yStep)
        {
            var done = false;
            var result = 0;
            var x = 0;
            var y = 0;
            while (!done)
            {
                if (input[y][x] == '#')
                {
                    result++;
                }
                
                x += xStep; 
                if (x >= input[y].Count)
                {
                    x -= input[y].Count;
                }
                
                y += yStep;
                if (y >= input.Count)
                {
                    done = true;
                }
            }

            return result;
        }
    }
}