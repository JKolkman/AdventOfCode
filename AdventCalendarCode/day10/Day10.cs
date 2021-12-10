using System;
using System.Collections.Generic;

namespace AdventCalendarCode.day10
{
    public class Day10
    {
        private readonly string[] _input;

        private static readonly Dictionary<char, char> MatchingCharacters = new Dictionary<char, char>
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'}
        };

        private static readonly Dictionary<char, int> Task1Values = new Dictionary<char, int>()
        {
            {')', 3},
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };

        private static readonly Dictionary<char, int> Task2Values = new Dictionary<char, int>()
        {
            {'(', 1},
            {'[', 2},
            {'{', 3},
            {'<', 4}
        };

        public Day10(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day10\Day10-TestInput.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\AdventCalendarCode\day10\Day10-Input.txt")
            };

            Console.WriteLine("--Day 10--");
            Tasks();
        }

        private void Tasks()
        {
            var score = 0;
            var task2Scores = new List<long>();
            
            foreach (var line in _input)
            {
                var stack = new Stack<char>();
                foreach (var c in line.ToCharArray())
                {
                    if (MatchingCharacters.ContainsKey(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        if (c == MatchingCharacters[stack.Pop()]) continue;
                        score += Task1Values[c];
                        break;
                    }
                }

                if (score != 0) continue;
                {
                    long t2Score = 0;
                    while (stack.Count > 0)
                    {
                        t2Score *= 5;
                        t2Score += Task2Values[stack.Pop()];
                    }
                    task2Scores.Add(t2Score);
                }
            }
            
            task2Scores.Sort();
            var middle = task2Scores.Count / 2;
            Console.WriteLine($"Task 1: {score}");
            Console.WriteLine($"Task 2: {task2Scores[middle]}");
        }
    }
}