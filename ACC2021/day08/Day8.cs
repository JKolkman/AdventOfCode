using System;
using System.Linq;

namespace AdventCalendarCode.day08
{
    public class Day8 : IDay
    {
        private readonly string[] _input;

        public Day8(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day08\Day8-TestInput.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day08\Day8-Input.txt")
            };
        }

        public void Run()
        {
            Task1();
            Task2();
        }

        private void Task1()
        {
            var timer = DateTime.UtcNow;
            var count = (from line in _input select line.Split("|")[1].Trim() into afterDelimiter select afterDelimiter.Split(" ") into results select results.Count(res => res.Length is 2 or 3 or 4 or 7)).Sum();
            Console.WriteLine($"08.1: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine($"(1) {count}");
        }

        private void Task2()
        {
            var timer = DateTime.UtcNow;
            var dataSet = Array.ConvertAll(_input, s => s.Split("|")[0].Trim().Split(" "));
            var resultSet = Array.ConvertAll(_input, s => s.Split("|")[1].Trim().Split(" "));
            var total = 0;
            for (var i = 0; i < dataSet.Length; i++)
            {
                var singleSet = dataSet[i];
                var digital = new[] {"", "", "", "", "", "", ""};
                /*
                 * 0: Top
                 * 1: TopLeft
                 * 2: TopRight
                 * 3: Middle
                 * 4: BottomLeft
                 * 5: BottomRight
                 * 6: Bottom
                 */
                var numbers = new[] {"", "", "", "", "", "", "", "", "", ""};
                var keepLooping = true;
                var count = 0;
                while (keepLooping)
                {
                    count++;
                    keepLooping = false;
                    foreach (var s in singleSet)
                    {
                        var code = SortString(s);
                        var skipStep = false;
                        foreach (var n in numbers)
                        {
                            if (n == code)
                            {
                                skipStep = true;
                            }
                        }

                        if (skipStep) continue;
                        
                        switch (code.Length)
                        {
                            case 2:
                                numbers[1] = code;
                                break;
                            case 3:
                                numbers[7] = code;
                                break;
                            case 4:
                                numbers[4] = code;
                                break;
                            case 5:
                                if (numbers[3] == "")
                                {
                                    if (numbers[1] != "")
                                    {
                                        var isThree = true;
                                        foreach (var n in numbers[1].Where(n => !code.Contains(n.ToString())))
                                        {
                                            isThree = false;
                                        }

                                        if (isThree)
                                        {
                                            numbers[3] = code;
                                            break;
                                        }
                                    }

                                    if (numbers[2] != "" && numbers[5] != "")
                                    {
                                        numbers[3] = code;
                                    }
                                }
                                
                                if (numbers[2] == "")
                                {
                                    if (digital[4] != "" && code.Contains(digital[4]))
                                    {
                                        numbers[2] = code;
                                        break;
                                    }
                                    
                                    if (numbers[3] != "" && numbers[5] != "")
                                    {
                                        numbers[2] = code;
                                        break;
                                    }
                                }

                                if (numbers[5] == "")
                                {
                                    if (numbers[2] != "" && numbers[3] != "")
                                    {
                                        numbers[5] = code;
                                        break;
                                    }
                                }
                                break;
                            case 6:
                                if (numbers[0] == "")
                                {
                                    if (numbers[8] != "" && digital[3] != "")
                                    {
                                        numbers[0] = numbers[8].Replace(digital[3], "");
                                        break;
                                    }
                                }

                                if (numbers[6] == "")
                                {
                                    if (numbers[9] != "" && numbers[0] != "")
                                    {
                                        numbers[6] = code;
                                        break;
                                    }
                                }
                                
                                if (numbers[9] == "")
                                {
                                    if (digital[4] != "")
                                    {
                                        if (!code.Contains(digital[4]))
                                        {
                                            numbers[9] = code;
                                            break;
                                        }
                                    }
                                }
                                break;
                            case 7:
                                numbers[8] = code;
                                break;
                        }
                        
                        // Functions for figuring out digitals
                        // Digital[0]
                        if (digital[0] == "")
                        {
                            if (numbers[1] != "" && numbers[7] != "")
                            {
                                digital[0] = numbers[1].Aggregate(numbers[7], (current, c) => current.Replace(c.ToString(), ""));
                            }
                        }

                        // Digital[1]
                        if (digital[1] == "")
                        {
                            
                        }
                        
                        // Digital[2]
                        if (digital[2] == "")
                        {
                            if (numbers[6] != "")
                            {
                                digital[2] = numbers[6].Aggregate(numbers[8],
                                    (current, c) => current.Replace(c.ToString(), ""));
                            }
                        }
                        
                        // Digital[3]
                        if (digital[3] == "")
                        {
                            if (numbers[3] != "" && numbers[7] != "" && digital[6] != "" )
                            {
                                var removeSeven = numbers[7].Aggregate(numbers[3], (current, c) => current.Replace(c.ToString(), ""));
                                digital[3] = removeSeven.Replace(digital[6], "");
                            }
                        }
                        
                        // Digital[4]
                        if (digital[4] == "")
                        {
                            if (numbers[3] != "" && numbers[4] != "")
                            {
                                var removeThree = numbers[3].Aggregate(numbers[8], (current, c) => current.Replace(c.ToString(), ""));
                                digital[4] = numbers[4].Aggregate(removeThree, (current, c) => current.Replace(c.ToString(), ""));
                            }
                        }
                        
                        // Digital[5]
                        if (digital[5] == "")
                        {
                            
                        }
                        
                        // Digital[6]
                        if (digital[6] == "")
                        {
                            if (numbers[3] != "" && numbers[4] != "" && digital[0] != "")
                            {
                                var removeFour = numbers[4].Aggregate(numbers[3], (current, c) => current.Replace(c.ToString(), ""));
                                digital[6] = removeFour.Replace(digital[0], "");
                            }
                        }
                    }
                    
                    foreach (var num in numbers)
                    {
                        if (string.IsNullOrEmpty(num))
                        {
                            keepLooping = true;
                        }
                    }

                    if (count > 15)
                    {
                        keepLooping = false;
                    }
                }

                var numOfSingleSet = "";
                for (var j = 0; j < resultSet[i].Length; j++)
                {
                    var r = SortString(resultSet[i][j]);
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (numbers[k] == r)
                        {
                            numOfSingleSet += k.ToString();
                        }
                    }
                }

                total += int.Parse(numOfSingleSet);
            }
            Console.WriteLine($"08.2: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.Write("        ");
            //Console.WriteLine($"(2) {total}");
        }
        
        private static string SortString(string input)
        {
            var characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}