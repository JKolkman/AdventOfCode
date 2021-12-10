using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventCalendarCode.day10
{
    public class Day10
    {
        private readonly string[] _input;

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
                const string openings = "([{<";
                const string closers = ")]}>";
                var stack = new Stack();
                var legalLine = true;
                foreach (var c in line.ToCharArray())
                {
                    var charIsIllegal = false;
                    if (openings.Contains(c))
                    {
                        stack.Push(c);
                    } else if (closers.Contains(c))
                    {
                        var stackTop = stack.Pop();
                        switch (stackTop)
                        {
                            case '(':
                                if (c != ')')
                                {
                                    charIsIllegal = true;
                                }
                                break;
                            case '[':
                                if (c != ']')
                                {
                                    charIsIllegal = true;
                                }
                                break;
                            case '{':
                                if (c != '}')
                                {
                                    charIsIllegal = true;
                                }
                                break;
                            case '<':
                                if (c != '>')
                                {
                                    charIsIllegal = true;
                                }
                                break;
                        }
                    }

                    if (!charIsIllegal) continue;
                    score += IllegalCharValue(c);
                    legalLine = false;
                    break;
                }

                if (!legalLine) continue;
                {
                    long t2Score = 0;
                    while (stack.Count > 0)
                    {
                        t2Score *= 5;
                        var stackTop = stack.Pop();
                        switch (stackTop)
                        {
                            case '(':
                                t2Score += 1;
                                break;
                            case '[':
                                t2Score += 2;
                                break;
                            case '{':
                                t2Score += 3;
                                break;
                            case '<':
                                t2Score += 4;
                                break;
                        }
                    }
                    task2Scores.Add(t2Score);
                }
            }

            task2Scores.Sort();
            var middle = task2Scores.Count / 2;
            Console.WriteLine($"Task 1: {score}");
            Console.WriteLine($"Task 2: {task2Scores[middle]}");
        }

        private static int IllegalCharValue(char c)
        {
            return c switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => 0
            };
        }
    }
}