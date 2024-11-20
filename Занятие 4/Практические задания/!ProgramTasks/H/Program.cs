
﻿using System;
namespace H
{
    internal class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static bool CheckWin(Mark[,] field, Mark marker)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((field[i, 0] == marker && field[i, 1] == marker && field[i, 2] == marker) ||
                    (field[0, i] == marker && field[1, i] == marker && field[2, i] == marker))
                {
                    return true;
                }
            }
            if ((field[0, 0] == marker && field[1, 1] == marker && field[2, 2] == marker) ||
                (field[0, 2] == marker && field[1, 1] == marker && field[2, 0] == marker))
            {
                return true;
            }

            return false;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            bool crossWin = CheckWin(field, Mark.Cross);
            bool circleWin = CheckWin(field, Mark.Circle);

            if (crossWin && circleWin)
                return GameResult.Draw; 
            if (crossWin)
                return GameResult.CrossWin;
            if (circleWin)
                return GameResult.CircleWin;

            return GameResult.Draw;
        }

            private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
    }
}
