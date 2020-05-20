using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GameUtilities
    {

        /*
         * *** To Implement
         *
         * Input: Integer row number, Integer column number, Random random number generator
         * Output: a 2D Boolean array
         * 
         * Expected behavoir: 
         * - Create a new Boolean array with the specified row & column numbers
         * - Randomly assign True or False to every cell in the 2D array using the random number generator
         *      - *Easier*: Assign True/False with 50% probability
         *      - *Harder*: Assign True with 20% probability, False with 80%
         * - Return the filled 2D array
        */
        public static bool[,] GenerateRandomBoard(int rows, int cols, Random randomGenerator)
        {
            bool[,] myGrid = new bool[rows, cols];
            for (int r = 0; r < myGrid.GetLength(0); r++)
            {
                for (int c = 0; c < myGrid.GetLength(1); c++)
                {
                    int randomNumber = randomGenerator.Next(2);
                    if (randomNumber == 0)
                        myGrid[r, c] = true;
                }
            }
            return myGrid;
        }


        /*
         * *** To Implement
         *
         * Input: a 2D Boolean array
         * Output: a 2D Boolean array
         * 
         * Expected behavoir: 
         * - Visit every cell in the input array, and do the following:
         *   - Count the number of "alive" neighbours each cell has
         *      *Hint: use the "CountNeighbours" function for this!
         *   - Based on 
         *     (1) the number of alive neighbours, and 
         *     (2) the current state of the cell
         *     determine if this cell should be "alive" or "dead" in the next generation.
         * 
         * - Return the newly filled 2D array
        */
        public static bool[,] CalculateNextGeneration(bool[,] currentGen)
        {
            bool[,] newGen = new bool[currentGen.GetLength(0), currentGen.GetLength(1)];
            for (int r = 0; r < currentGen.GetLength(0); r++)
            {
                for (int c = 0; c < currentGen.GetLength(1); c++)
                {
                    int count = CountNeighbours(r, c, currentGen);

                    if (currentGen[r, c])
                    {
                        if (count == 2 || count == 3)
                            newGen[r, c] = true;
                        if (count < 2 || count > 3)
                            newGen[r, c] = false;
                    }
                    else
                    {
                        if (count == 3)
                            newGen[r, c] = true;
                    }
                }
            }
            return newGen;
        }

        /*
         * *** To Implement
         *
         * Input: Integer row number, Integer colunm number, 2D Boolean array
         * Output: an Integer (indicating the number of alive neighbours)
         * 
         * Expected behavoir: 
         * - *Most* cells have 8 neighbours. Count how many are alive!
         * - *Some* cells have less than 8 neighbours (edges, corners).
         *     You'll need to figure out how to avoid the "off by one" error
         *     to handle these cells.
         * - Return the number of alive neighbours.
        */
        public static int CountNeighbours(int row, int col, bool[,] currentGen)
        {

            int count = 0;

            if ((row - 1 >= 0 && col - 1 > 0) && currentGen[row - 1, col - 1] == true)
                count++;
            if ((row - 1 >= 0) && currentGen[row - 1, col] == true)
                count++;
            if ((row - 1 >= 0 && col + 1 < currentGen.GetLength(1)) && currentGen[row - 1, col + 1] == true)
                count++;
            if ((col - 1 >= 0) && currentGen[row, col - 1] == true)
                count++;
            if ((col + 1 < currentGen.GetLength(1)) && currentGen[row, col + 1] == true)
                count++;
            if ((row + 1 < currentGen.GetLength(0) && col - 1 >= 0) && currentGen[row + 1, col - 1] == true)
                count++;
            if ((row + 1 < currentGen.GetLength(0)) && currentGen[row + 1, col] == true)
                count++;
            if ((row + 1 < currentGen.GetLength(0) && col + 1 < currentGen.GetLength(1)) && currentGen[row + 1, col + 1] == true)
                count++;

            return count;
        }


        /*
         * Sample function: checks to see if two game states are equal to eachother 
         * (i.e., every cell is the same)
         * *Assumes the two game states have the same number of rows/columns.*
         */
        public bool Equals(bool[,] g1, bool[,] g2)
        {
            for (int r = 0; r < g1.GetLength(0); r++)
            {
                for (int c = 0; c < g2.GetLength(1); c++)
                {
                    if (g1[r, c] != g2[r, c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
