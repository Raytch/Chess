using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {
        // size of board usually = 8x8
        public int Size { get; set; }

        // 2D array of type cell
        public Cell[,] TheGrid { get; set; }

        //constructor
        public Board (int s, string cp)
        {
            // defines initial board size
            Size = s;

            // create new 2D array of type cell
            TheGrid = new Cell[Size, Size];

            // fill the 2D array with new cells, each with unique x & y coordinates
            for (int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].LegalNextMove = false;
                    TheGrid[i, j].CurrentlyOccupied = false;
                }
            }

            // find all legal moves and mark the cells as legal
            switch (chessPiece)
            {
                case "Knight":
                    TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    break;

                case "King":
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                default:
                    break;
            }
            TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
    }
}
