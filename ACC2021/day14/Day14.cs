using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventCalendarCode.day14
{
    public class Day14 : IDay
    {
        private readonly string[] _input;

        public Day14(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day14\Day14-Test-Input.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day14\Day14-Input.txt")
            };
        }

        public void Run()
        {
            var template = _input[0];
            var insertionRules = _input.Skip(2).ToArray();
            Console.Write("Day 14: ");
            Tasks(template, insertionRules, 10, 1);
            Console.Write("        ");
            Tasks(template, insertionRules, 40, 2);
        }

        private static void Tasks(string template, string[] insertionRules, int steps, int task)
        {
            var dictionary = new Dictionary<string, double>();
            var charCount = new Dictionary<string, double>();
            for (var i = 0; i < template.Length; i++)
            {
                charCount = IncreaseDictionary(charCount, template.Substring(i, 1), 1);
                
                if (i + 1 >= template.Length) continue;
                dictionary = IncreaseDictionary(dictionary, template.Substring(i, 2), 1);
            }

            for (var i = 0; i < steps; i++)
            {
                var bufferDict = new Dictionary<string, double>(dictionary);
                foreach (var rule in insertionRules)
                {
                    var ruleSplit = rule.Split(" -> ");
                    if (!dictionary.ContainsKey(ruleSplit[0])) continue;
                    bufferDict[ruleSplit[0]] -= dictionary[ruleSplit[0]];
                    var rule1 = ruleSplit[0].ToCharArray()[0] + ruleSplit[1];
                    var rule2 = ruleSplit[1] + ruleSplit[0].ToCharArray()[1];

                    bufferDict = IncreaseDictionary(bufferDict, rule1, dictionary[ruleSplit[0]]);
                    bufferDict = IncreaseDictionary(bufferDict, rule2, dictionary[ruleSplit[0]]);
                    charCount = IncreaseDictionary(charCount, ruleSplit[1], dictionary[ruleSplit[0]]);
                }
                dictionary = new Dictionary<string, double>(bufferDict);
            }
            Console.WriteLine($"({task}) {charCount.Values.Max() - charCount.Values.Min()}");
        }

        private static Dictionary<string, double> IncreaseDictionary(Dictionary<string, double> dict,string key, double value)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, 0);

            dict[key] += value;
            
            return dict;
        }
    }
}