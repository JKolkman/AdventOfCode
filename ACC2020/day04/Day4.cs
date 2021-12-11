using System;
using System.Linq;

namespace ACC2020.day04
{
    public class Day4 : IDay
    {
        public void Run(bool testRun)
        {
            var input = System.IO.File.ReadAllLines(testRun switch
            {
                true => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day04\d4-test-input.txt",
                false => @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2020\day04\d4-input.txt"
            });
            Console.WriteLine("D4");
            Task1(input);
        }

        private void Task1(string[] input)
        {
            var count = 0;
            var passport = "";

            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    var list = passport.Trim().Split(" ");
                    if (list.Length >= 7)
                    {
                        var correct = true;
                        foreach (var item in list)
                        {
                            if (item.Split(":")[0] == "cid" && list.Length != 8)
                            {
                                correct = false;
                            }
                        }

                        if (correct)
                        {
                            count++;
                        }
                    }
                    
                    passport = "";
                }
                else
                {
                    passport += line + " ";
                }
                
            }
            Console.WriteLine(count);
        }
    }
}