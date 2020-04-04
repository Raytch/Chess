using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Program
    {
        static Board myBoard = new Board(8, "");

        static void Main(string[] args)
        {
            // show the empty chess board
            printBoard(myBoard);

            // request coordinates from user where piece will be placed
            Cell currentCell = setCurrentCell();
            string chessPiece = setPieceType();
            currentCell.CurrentlyOccupied = true;


            // calculate all legal moves for that piece
            myBoard.MarkNextLegalMoves(currentCell, chessPiece);

            // print the chess board. Use an X for occupied square. Use a + for legal move. Use . for empty cell.
            printBoard(myBoard);


            // wait for user to press enter key before ending the program
            Console.ReadLine();
        }

        private static string setPieceType()
        {
            Console.WriteLine("Which Chess piece would you like to place? Knight, King, Queen, Rook or Bishop");
            string chessPiece = Console.ReadLine();

            return chessPiece;
        }

        private static Cell setCurrentCell()
        {
            //get x & y coordinate from user. return a cell location.
            Console.WriteLine("Enter the current Row number: ");
            int currentRowNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the current Column number: ");
            int currentColumnNum = int.Parse(Console.ReadLine());

            return myBoard.TheGrid[currentRowNum, currentColumnNum];
        }

        private static void printBoard(Board myBoard)
        {
            // print the chess board Use an X for piece location. Use + for legal move. Use . for empty cell.
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Console.Write("|");

                    Cell c = myBoard.TheGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write(" x ");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.Write("|");

                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+---+---+---+---+---+");

            Console.WriteLine("=====================================");
        }
    }
}
