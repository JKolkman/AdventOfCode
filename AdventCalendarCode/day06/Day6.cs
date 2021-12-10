using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day6
{
    public class Day6
    {
        private string[] _input;
        private List<int> fish;
        public Day6()
        {
            _input = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day06\Day6-Input.txt");
            fish = new List<int>(Array.ConvertAll(_input[0].Split(","), int.Parse));
            //fish = new List<int>() {3, 4, 3, 1, 2};
            
            
            Console.Write("Day 06: ");
            Console.Write("(1) ");
            Tasks(80);
            Console.Write($"        ");
            Console.Write("(2) ");
            Tasks(256);
        }

        private void Tasks(int days)
        {
            var fishLifeSpan = new double[9];

            foreach (var f in fish)
            {
                fishLifeSpan[f]++;
            }
            for (var i = 0; i < days; i++)
            {
                var buffer = new double[9];
                for (var j = 0; j < fishLifeSpan.Length; j++)
                {
                    if (j == 0)
                    {
                        buffer[6] += fishLifeSpan[j];
                        buffer[8] += fishLifeSpan[j];
                    }
                    else
                    {
                        buffer[j - 1] += fishLifeSpan[j];
                    }
                }

                fishLifeSpan = buffer;
            }
            Console.WriteLine($"{fishLifeSpan.Sum()}");
        }
    }
}