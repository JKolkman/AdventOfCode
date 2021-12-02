using System;

namespace AdventCalendarCode.day2
{
    public class Day2
    {
        private string[] _lines;
        
        public void Run()
        {
            _lines = System.IO.File.ReadAllLines(@"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day2\Day2-Input");
            
            Console.WriteLine("--Day 2--");
            BothTasks();
        }

        private void BothTasks()
        {
            var nums = new int[] {0,0,0}; // 0 Depth, 1 Aim, 2 Dist
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
            
            Console.WriteLine($"Task 1: {nums[1] * nums[2]}");
            Console.WriteLine($"Task 2: {nums[0] * nums[2]}\n");
        }
    }
}