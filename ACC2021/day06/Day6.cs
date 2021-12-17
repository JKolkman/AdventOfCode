using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day06
{
    public class Day6 : IDay
    {
        private readonly List<int> _fish;

        public Day6()
        {
            var input = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day06\Day6-Input.txt");
            _fish = new List<int>(Array.ConvertAll(input[0].Split(","), int.Parse));
            //fish = new List<int>() {3, 4, 3, 1, 2};
        }

        public void Run()
        {
            Console.Write("06.1: ");
            Tasks(80);
            Console.Write("06.2: ");
            Tasks(256);
        }

        private void Tasks(int days)
        {
            var timer = DateTime.UtcNow;
            var fishLifeSpan = new double[9];

            foreach (var f in _fish)
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
            Console.WriteLine($"{(DateTime.UtcNow - timer).TotalMilliseconds}ms ");
            //Console.WriteLine($"{fishLifeSpan.Sum()}");
        }
    }
}