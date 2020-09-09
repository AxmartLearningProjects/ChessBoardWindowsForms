using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUI
{
    public partial class Form1 : Form
    {
        // reference to the class Board
       static Board myBoard = new Board(8);

        // 2D array of buttons whose values determind by myBoard
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();

            populateGrid();
        }

        private void populateGrid()
        {
            //create buttons and place them into panel1

            int buttonSize = panel1.Width / myBoard.Size;

            //make sure it's a square
            panel1.Height = panel1.Width;

            //nested for loops to create buttons

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {

                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    //add a click event to each button
                    btnGrid[i, j].Click += Grid_Button_Click;

                    // add the new button to the panel
                    panel1.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    //btnGrid[i, j].Text = i + " | " + j;
                    btnGrid[i, j].Tag = new Point(i, j);


                }


            }


        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {

            // get the row and the col number for the button
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            //int x = location.X;
            //int y = location.Y;

            Cell currentCell = myBoard.TheGrid[location.X, location.Y];

            // determine legal next moves

            myBoard.MarkNextLegalMoves(currentCell, comboBox1.Text.ToLower());


            //update the text on each button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = string.Empty;

                    if (myBoard.TheGrid[i,j].LegalNextMove)
                    {
                        btnGrid[i, j].Text = "Legal";
                    }
                    else if (myBoard.TheGrid[i,j].CurrentlyOccupied)
                    {
                        btnGrid[i, j].Text = comboBox1.Text;
                    }

                }
            }


        }
    }
}
