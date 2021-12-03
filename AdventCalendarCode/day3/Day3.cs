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
            var nums = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var oxygen = _lines.ToList();
            var co2 = _lines.ToList();
            for (var i = 0; i < nums.Length; i++)
            {
                var value = findCommon(oxygen.ToArray(), i);
                oxygen.RemoveAll(s => s.ToCharArray()[i].ToString().Equals(value));
                value = findCommon(co2.ToArray(), i, true, false); 
                co2.RemoveAll(s => s.ToCharArray()[i].ToString().Equals(value));
            }
            
            Console.WriteLine($"Task 2: {(Convert.ToInt32(oxygen.ToArray()[0], 2) * Convert.ToInt32(co2.ToArray()[0], 2))}\n");

        }

        private string findCommon(string[] list, int index, bool invert = false, bool ox = true)
        {
            var items = new[] {0, 0};
            foreach (var item in list)
            {
                items[int.Parse(item.ToCharArray()[index].ToString())]++;
            }

            if (items[0] == 0 || items[1] == 0)
            {
                return "X";
            }
            if (items[0] > items[1])
            {
                return invert ? "1" : "0";
            }
            if (items[0] == items[1])
            {
                return ox ? "1" : "0";
            }
            return invert ? "0" : "1";
        }
    }
}