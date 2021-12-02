using System;

namespace AdventCalendarCode.day2
{
    public class Day2
    {
        private string[] _lines;
        
        public void Run()
        {
            _lines = System.IO.File.ReadAllLines(@"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day2\Day2-Input");
            
            Console.WriteLine("Results of Day 2");
            Console.WriteLine(Task1());
            Console.WriteLine(Task2());
            Console.WriteLine();
        }

        private string Task1()
        {
            var depth = 0;
            var horizontal = 0;
            foreach (var line in _lines)
            {
                var split = line.Split(" ");
                var i = split[0] switch
                {
                    "forward" => horizontal += int.Parse(split[1]),
                    "down" => depth += int.Parse(split[1]),
                    "up" => depth -= int.Parse(split[1]),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            var answer = depth * horizontal;

            return $"The depth * horizontal = {answer}";
        }

        public string Task2()
        {
            var depth = 0;
            var horizontal = 0;
            var aim = 0;
            foreach (var line in _lines)
            {
                var split = line.Split(" ");
                switch (split[0])
                {
                    case "forward":
                        horizontal += int.Parse(split[1]);
                        depth += (int.Parse(split[1]) * aim);
                        break;
                    case "down":
                        aim += int.Parse(split[1]);
                        break;
                    case "up":
                        aim -= int.Parse(split[1]);
                        break;
                }
            }

            var answer = depth * horizontal;
            return $"The depth * horizontal = {answer}";
        }
    }
}