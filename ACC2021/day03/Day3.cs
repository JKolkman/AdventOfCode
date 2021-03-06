using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day03
{
    public class Day3 : IDay
    {
        private readonly string[] _lines;

        public Day3()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day03\Day3-Input.txt");
        }

        public void Run()
        {
            Task1();
            Task2();
        }

        private void Task1()
        {
            var timer = DateTime.UtcNow;
            var nums = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach (var line in _lines)
            {
                var chars = line.ToCharArray();
                for (var i = 0; i < chars.Length; i++)
                {
                    nums[i] += int.Parse(chars[i].ToString());
                }
            }

            var gamma = "";
            var epsilon = "";

            foreach (var num in nums)
            {
                switch (num)
                {
                    case > 500:
                        gamma += "1";
                        epsilon += "0";
                        break;
                    case < 500:
                        gamma += "0";
                        epsilon += "1";
                        break;
                    default:
                        Console.WriteLine($"Unexpected Number gotten {num}");
                        break;
                }
            }
            Console.WriteLine($"03.1: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine($"(1) {(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2))}");
        }

        private void Task2()
        {
            var timer = DateTime.UtcNow;
            var oxygen = _lines.ToList();
            var co2 = _lines.ToList();
            
            for (var i = 0; i < 12; i++)
            {
                oxygen = ReturnCuratedList(oxygen, i, true);
                co2 = ReturnCuratedList(co2, i, false);
            }
            Console.WriteLine($"03.2: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.Write("        ");
            //Console.WriteLine($"(2) {(Convert.ToInt32(oxygen.ToArray()[0], 2) * Convert.ToInt32(co2.ToArray()[0], 2))}");
        }

        private static List<string> ReturnCuratedList(List<string> input, int i, bool oxygen)
        {
            var zeroes = input.FindAll(x => x.ToCharArray()[i].Equals('0')).Count;
            var ones = input.FindAll(x => x.ToCharArray()[i].Equals('1')).Count;
            char remove;
            if (zeroes == 0 || ones == 0)
            { } else if (zeroes <= ones)
            {
                remove = oxygen ? '0' : '1';
                input.RemoveAll(x => x.ToCharArray()[i].Equals(remove));
            } else 
            {
                remove = oxygen ? '1' : '0';
                input.RemoveAll(x => x.ToCharArray()[i].Equals(remove));
            }
            return input;
        }
    }
}