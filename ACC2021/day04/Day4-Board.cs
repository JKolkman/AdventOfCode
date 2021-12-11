using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCalendarCode.day4
{
    public class Day4_Board
    {
        private bool boardComplete = false;
        private (int, bool)[,] _board;

        public Day4_Board(IReadOnlyList<string> input)
        {
            _board = new (int, bool)[,] {
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)}};
            for (var i = 0; i < input.Count; i++)
            {
                var inputSplit = input[i].Split(" ");
                inputSplit = inputSplit.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                
                var line = Array.ConvertAll(inputSplit, int.Parse);

                for (var j = 0; j < line.Length; j++)
                {
                    if (_board != null) _board[i, j] = (line[j], false);
                }
            }
        }

        public (bool, int) AddNumber(int num)
        {
            if (boardComplete)
            {
                return (false, 0);
            }
            checkIfOnCard(num);
            var complete = CheckComplete();
            if (!complete) return (false, 0);
            
            var res = 0;
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (!_board[i, j].Item2)
                    { res += _board[i, j].Item1; }
                }
            }

            boardComplete = true;
            return (true, res);
        }

        private void checkIfOnCard(int num)
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j].Item1 != num) continue;
                    _board[i, j].Item2 = true;
                }
            }
        }

        private bool CheckComplete()
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                var length = 0;
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j].Item2)
                    {
                        length++;
                    }
                    else
                    {
                        length = 0;
                    }
                }

                if (length == 5)
                {
                    return true;
                }
            }
            for (var i = 0; i < _board.GetLength(1); i++)
            {
                var length = 0;
                for (var j = 0; j < _board.GetLength(0); j++)
                {
                    if (_board[j,i].Item2)
                    {
                        length++;
                    }
                    else
                    {
                        length = 0;
                    }
                }

                if (length == 5)
                {
                    return true;
                }
            }
            return false;
        }
    }
}