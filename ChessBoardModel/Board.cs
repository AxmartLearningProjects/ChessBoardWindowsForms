using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {

        public int Size { get; set; }

        public Cell[,] TheGrid { get; set; }

        public Board(int size)
        {
            // The inital board size is defined by size
            Size = size;

            // create a new 2D array of type cell
            TheGrid = new Cell[Size, Size];


            // fill the 2D array with new Cells, each with unique x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }

        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {

            // clear the board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].CurrentlyOccupied = false;
                    TheGrid[i, j].LegalNextMove = false;
                }
            }


            // find all legal moves and mark the cells as legal

            switch (chessPiece)
            {
                case "knight":
                    markCell(currentCell, 2, 1);
                    markCell(currentCell, 2, -1);
                    markCell(currentCell, -2, 1);
                    markCell(currentCell, -2, -1);
                    markCell(currentCell, 1, 2);
                    markCell(currentCell, 1, -2);
                    markCell(currentCell, -1, 2);
                    markCell(currentCell, -1, -2);


                    break;

                case "king":
                    markCell(currentCell, 0, 1);
                    markCell(currentCell, 0, -1);
                    markCell(currentCell, 1, 0);
                    markCell(currentCell, 1, 1);
                    markCell(currentCell, 1, -1);
                    markCell(currentCell, -1, 0);
                    markCell(currentCell, -1, 1);
                    markCell(currentCell, -1, -1);
                    
                    

                    break;

                case "rook":
                    for (int i = 1; i < this.Size; i++)
                    {
                        markCell(currentCell, i, 0);
                        markCell(currentCell, i*-1, 0);
                        markCell(currentCell, 0, i);
                        markCell(currentCell, 0, i*-1);

                    }
                    break;

                case "bishop":
                    for (int i = 1; i < this.Size; i++)
                    {
                        markCell(currentCell, i, i);
                        markCell(currentCell, i * -1, i);
                        markCell(currentCell, i*-1, i*-1);
                        markCell(currentCell, i, i * -1);

                    }
                    break;

                case "queen":
                    for (int i = 1; i < this.Size; i++)
                    {
                    markCell(currentCell, i, 0);
                    markCell(currentCell, i * -1, 0);
                    markCell(currentCell, 0, i);
                    markCell(currentCell, 0, i * -1);
                    markCell(currentCell, i, i);
                    markCell(currentCell, i * -1, i);
                    markCell(currentCell, i*-1, i*-1);
                    markCell(currentCell, i, i * -1);
                    }

                    break;

            }
            TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;


        }


        private void markCell(Cell currentCell, int row, int column)

        {
            if (cellIsSafe(currentCell,row,column))
            {
                TheGrid[currentCell.RowNumber + row, currentCell.ColumnNumber + column].LegalNextMove = true;
            }
           


        }

        private bool cellIsSafe(Cell currentCell,int row, int column)
        {

            return this.Size > currentCell.RowNumber + row && this.Size > currentCell.ColumnNumber + column && 0 <= currentCell.RowNumber + row && 0 <= currentCell.ColumnNumber + column;
            

        }
    }
}
