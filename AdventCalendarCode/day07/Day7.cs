using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace AdventCalendarCode.day7
{
    public class Day7
    {
        private string[] _input;
        private int[] _inputNum;
        public Day7()
        {
            _input = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day7\Day7-Input.txt");
            _inputNum = Array.ConvertAll(_input[0].Split(","), int.Parse);
            //_inputNum = new int[]{16, 1, 2, 0, 4, 2, 7, 1, 2, 14};
            Console.WriteLine("--Day 7--");
            BothTasks();
        }

        private void BothTasks()
        {
            
            var numberCount = _inputNum.Length;
            var halfIndex = _inputNum.Length / 2;
            var sortedNumbers = _inputNum.OrderBy(n=>n).ToArray();
            var median = 0;
            if (numberCount % 2 == 0)
            {
                median = ((sortedNumbers[halfIndex] + sortedNumbers[halfIndex - 1]) / 2);
            } 
            else
            {
                median = sortedNumbers[halfIndex];
            }
            var averageFloor = (int)Math.Floor((decimal)_inputNum.Sum() / numberCount);
            var averageCeil = (int)Math.Ceiling((decimal)_inputNum.Sum() / numberCount);
            var fuelTask1 = 0;
            var fuelTask2Floor = 0.0;
            var fuelTask2Ceil = 0.0;
                
            foreach (var num in _inputNum)
            {
                if (num > median)
                {
                    fuelTask1 += (num - median);
                } else if (num < median)
                {
                    fuelTask1 += (median - num);
                }

                if (num > averageFloor)
                {
                    fuelTask2Floor += ((0.5 * (num - averageFloor) * ((num-averageFloor + 1))));
                } else if (num < averageFloor)
                {
                    fuelTask2Floor += ((0.5 * (averageFloor - num) * ((averageFloor - num + 1))));
                }
                
                if (num > averageCeil)
                {
                    fuelTask2Ceil += ((0.5 * (num - averageCeil) * ((num-averageCeil + 1))));
                } else if (num < averageCeil)
                {
                    fuelTask2Ceil += ((0.5 * (averageCeil - num) * ((averageCeil - num + 1))));
                }
            }
            
            var task2res = (fuelTask2Ceil < fuelTask2Floor) ? fuelTask2Ceil : fuelTask2Floor;
            
            Console.WriteLine($"Task 1: {fuelTask1}");
            Console.WriteLine($"Task 2: {task2res}\n");
        }
    }
}