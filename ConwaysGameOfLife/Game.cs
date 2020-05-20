// andrewjivoin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConwaysGameOfLife
{
    public class Game
    {
        private bool[,] myGrid;
        private int myRows, myColumns, myCellWidth;
        private Brush myCellColor;

        public Game(Brush cellColor, int rows, int columns, int cellWidth)
        {
            myCellColor = cellColor;
            myRows = rows;
            myColumns = columns;
            myCellWidth = cellWidth;
            myGrid = new bool[myRows, myColumns];
        }


        public void InitialGeneration() 
        {
            myGrid = GameUtilities.GenerateRandomBoard(myRows, myColumns, new Random());
        }

        /*
        * to implement
        */
        public void NewGeneration()
        {
            myGrid = GameUtilities.CalculateNextGeneration(myGrid);
        }


        public void Paint(Graphics g)
        {
            for (int r = 0; r < myGrid.GetLength(0); r++)
            {
                for (int c = 0; c < myGrid.GetLength(1); c++)
                {
                    if (myGrid[r, c])
                    {
                        g.FillRectangle(myCellColor, c * myCellWidth, r * myCellWidth, myCellWidth, myCellWidth);
                    }
                }
            }
        }

        public bool[,] GetGrid()
        {
            return myGrid;
        }

        public void SetCellColor(Color c)
        {
            myCellColor = new SolidBrush(c);
        }
    }
}
