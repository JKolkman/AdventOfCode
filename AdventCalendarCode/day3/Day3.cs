using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day3
{
    public class Day3
    {
        private string[] _lines;

        public void Run()
        {
            _lines = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day3\Day3-Input.txt");

            Console.WriteLine("--Day 3--");
            Task1();
            Task2();
        }

        private void Task1()
        {
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
            
            Console.WriteLine($"Task 1: {(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2))}");
        }

        private void Task2()
        {
            var oxygen = _lines.ToList();
            var co2 = _lines.ToList();
            
            for (var i = 0; i < 12; i++)
            {
                oxygen = ReturnCuratedList(oxygen, i, true);
                co2 = ReturnCuratedList(co2, i, false);
            }
            Console.WriteLine($"Task 2: {(Convert.ToInt32(oxygen.ToArray()[0], 2) * Convert.ToInt32(co2.ToArray()[0], 2))}\n");
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