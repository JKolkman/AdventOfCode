using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day17
{
    public class Day17 : IDay
    {
        private readonly string _target;

        public Day17(bool test)
        {
            _target = test switch
            {
                true => "target area: x=20..30, y=-10..-5",
                false => "target area: x=102..157, y=-146..-90"
            };
        }

        public void Run()
        {
            var targets = _target.Split(":")[1].Trim().Split(",");
            var rangeX = Array.ConvertAll(targets[0].Trim().Replace("x=", "").Split(".."), int.Parse);
            var rangeY = Array.ConvertAll(targets[1].Trim().Replace("y=", "").Split(".."), int.Parse);
            
            Tasks(rangeX, rangeY);
        }

        private static void Tasks(IReadOnlyList<int> rangeX, IReadOnlyList<int> rangeY)
        {
            var timer = DateTime.UtcNow;
            var yHigh = 0;
            var count = 0;
            for (var x = 0; x <= rangeX[1]; x++)
            {
                var potentialY = 0;
                
                for (var y = rangeY[0]; y <= rangeX[0]/2-rangeY[0] ; y++)
                {
                    var cX = 0;
                    var cY = 0;
                    var step = 0;
                    while (true)
                    {
                        potentialY = cY > potentialY ? cY : potentialY;
                        var temp = x - step;
                        cX += temp > 0 ? temp : 0;
                        cY += y - step;
                        if (cX >= rangeX[0] && cX <= rangeX[1] && cY >= rangeY[0] && cY <= rangeY[1])
                        {
                            yHigh = (potentialY > yHigh) ? potentialY : yHigh;
                            count++;
                            break;
                        }

                        if (cX > rangeX[1] || cY < rangeY[0] || (temp < 0 && cX < rangeX[0]) )
                        {
                            break;
                        }

                        step++;
                    }
                }
            }
            Console.WriteLine($"17.X: {(DateTime.UtcNow - timer).TotalMilliseconds}ms");
            //Console.WriteLine(yHigh + " - " + count);
        }
    }
}