namespace AdventCalendarCode.day12
{
    public class Day12 : IDay
    {
        private readonly string[] _input;

        public Day12(bool test)
        {
            _input = test switch
            {
                true => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day12\Day12-Test-Input.txt"),
                false => System.IO.File.ReadAllLines(
                    @"C:\Users\Joost Kolkman\RiderProjects\AdventCalendarCode\ACC2021\day12\Day12-Input.txt")
            };
        }
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        private void Task1()
        {
        }
    }
}