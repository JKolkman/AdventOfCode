using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day16
{
    public class Day16 : IDay
    {
        private readonly string _input;

        private readonly Dictionary<char, string> _values = new()
        {
            {'0', "0000"},
            {'1', "0001"},
            {'2', "0010"},
            {'3', "0011"},
            {'4', "0100"},
            {'5', "0101"},
            {'6', "0110"},
            {'7', "0111"},
            {'8', "1000"},
            {'9', "1001"},
            {'A', "1010"},
            {'B', "1011"},
            {'C', "1100"},
            {'D', "1101"},
            {'E', "1110"},
            {'F', "1111"}
        };


        public Day16(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllText(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day16\Day16-Test-Input.txt"),
                false => System.IO.File.ReadAllText(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day16\Day16-Input.txt")
            };
        }

        public void Run()
        {
            var binary = "";
            _input.ToCharArray().ToList().ForEach(c => binary += _values[c]);
            //Console.WriteLine(binary);
            Console.WriteLine("16.X: FUCK THIS CHALLENGE");
        }

        private void Task1(string binary)
        {
            var timer = DateTime.UtcNow;
            var firstPacketVersion = binary[..3];
            var firstPacketType = binary.Substring(3, 3);
            
        }
    }
}