using System;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] chessBoard = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 8; j++)
                    chessBoard[i, j] = inputArgs[j];
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var figure = input[0].ToString();
                var startingRow = int.Parse(input[1].ToString());
                var startingCol = int.Parse(input[2].ToString());
                var endRow = int.Parse(input[4].ToString()); ;
                var endColumn = int.Parse(input[5].ToString()); ;

                if (chessBoard[startingRow, startingCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (OutOfBoard(endRow, endColumn))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    switch (figure)
                    {
                        case "K":
                            MoveKing(chessBoard, figure, startingRow, startingCol, endRow, endColumn);
                            break;
                        case "R":
                            MoveRook(chessBoard, figure, startingRow, startingCol, endRow, endColumn);
                            break;
                        case "B":
                            MoveBishop(chessBoard, figure, startingRow, startingCol, endRow, endColumn);
                            break;
                        case "Q":
                            MoveQueen(chessBoard, figure, startingRow, startingCol, endRow, endColumn);
                            break;
                        case "P":
                            MovePawn(chessBoard, figure, startingRow, startingCol, endRow, endColumn);
                            break;
                        default:
                            return;
                    }
                } 
            }
        }

        private static void MoveKing(string[,] chessBoard, string figure, int startingRow, int startingCol, int endRow, int endColumn)
        {
            if ((endRow == startingRow - 1 && endColumn == startingCol - 1)
                    || (endRow == startingRow - 1 && endColumn == startingCol)
                    || (endRow == startingRow - 1 && endColumn == startingCol + 1)
                    || (endRow == startingRow && endColumn == startingCol - 1)
                    || (endRow == startingRow && endColumn == startingCol + 1)
                    || (endRow == startingRow + 1 && endColumn == startingCol - 1)
                    || (endRow == startingRow + 1 && endColumn == startingCol)
                    || (endRow == startingRow + 1 && endColumn == startingCol + 1))
            {
                chessBoard[endRow, endColumn] = figure;
                chessBoard[startingRow, startingCol] = "x";
            }
            else
            {
                InvalidMove();
            }
        }

        private static void MoveBishop(string[,] chessBoard, string figure, int startingRow, int startingCol, int endRow, int endColumn)
        {
            if ((Math.Abs(startingRow - endRow) == Math.Abs(startingCol - endColumn)))
            {
                chessBoard[endRow, endColumn] = figure;
                chessBoard[startingRow, startingCol] = "x";
            }
            else
            {
                InvalidMove();
            }
        }

        private static void MoveRook(string[,] chessBoard, string figure, int startingRow, int startingCol, int endRow, int endColumn)
        {
            if ((startingRow == endRow) || (startingCol == endColumn))
            {
                chessBoard[endRow, endColumn] = figure;
                chessBoard[startingRow, startingCol] = "x";
            }
            else
            {
                InvalidMove();
            }
        }

        private static void MoveQueen(string[,] chessBoard, string figure, int startingRow, int startingCol, int endRow, int endColumn)
        {
            if ((startingRow == endRow) || 
                (startingCol == endColumn) ||
                (Math.Abs(startingRow-endRow) == Math.Abs(startingCol - endColumn)))

            {
                chessBoard[endRow, endColumn] = figure;
                chessBoard[startingRow, startingCol] = "x";
            }
            else
            {
                InvalidMove();
            }
        }

        private static void MovePawn(string[,] chessBoard, string figure, int startingRow, int startingCol, int endRow, int endColumn)
        {
            if ((startingRow - endRow == 1) && (startingCol == endColumn))
            {
                chessBoard[endRow, endColumn] = figure;
                chessBoard[startingRow, startingCol] = "x";
            }
            else
            {
                InvalidMove();
            }
        }

        private static void InvalidMove()
        {
            Console.WriteLine("Invalid move!");
        }

        private static bool OutOfBoard(int endRow, int endColumn)
        {
            if (endRow > 7 || endColumn > 7 || endRow < 0 || endColumn < 0)
            {
                return true;
            }
            return false;
        }
    }
}
