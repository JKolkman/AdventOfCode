using System;
using System.Linq;

namespace AdventCalendarCode.day07
{
    public class Day7 : IDay
    {
        private readonly int[] _inputNum;

        public Day7()
        {
            var input = System.IO.File.ReadAllLines(
                @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day07\Day7-Input.txt");
            _inputNum = Array.ConvertAll(input[0].Split(","), int.Parse);
            //_inputNum = new int[]{16, 1, 2, 0, 4, 2, 7, 1, 2, 14};
        }

        public void Run()
        {
            Console.Write("Day 07: ");
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
            
            Console.WriteLine($"(1) {fuelTask1}");
            Console.Write("        ");
            Console.WriteLine($"(2) {task2res}");
        }
    }
}