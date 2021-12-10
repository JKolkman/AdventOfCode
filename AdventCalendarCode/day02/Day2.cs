using System;

namespace AdventCalendarCode.day2
{
    public class Day2 : IDay
    {
        private string[] _lines;

        public Day2()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day02\Day2-Input");
        }

        public void Run()
        {
            Console.Write("Day 02: ");
            BothTasks();
        }

        private void BothTasks()
        {
            var nums = new int[] {0,0,0}; // 0 Depth, 1 Aim, 2 Distance
            foreach (var line in _lines)
            {
                var split = line.Split(" ");
                var num = int.Parse(split[1]);
                switch (split[0])
                {
                    case "forward":
                        nums[2] += num;
                        nums[0] += (num * nums[1]);
                        break;
                    case "down" :
                        nums[1] += num;
                        break;
                    case "up" :
                        nums[1] -= num;
                        break;
                }
            }
            
            Console.WriteLine($"(1) {nums[1] * nums[2]}");
            Console.WriteLine($"        (2) {nums[0] * nums[2]}");
        }
    }
}