using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SystemsOfEquations
{
    class SystemSolver
    {
        // The system solver takes in a 2D (square) array of doubles? 
        // [(x, y) ordered pairs -> input into the array upon construction].
        private double[,] matrix;

        // For n points, the polynomial will be of degree/order n - 1.
        // Need a constructor that takes a list of coordinates.
        public SystemSolver(List<Coordinate> coordinates)
        {
            // For now we assume that the input will result in a proper
            // entry that results in a n - 1 order polynomial and that the number
            // of coordinates entered is >= 2.
            int degree = coordinates.Count - 1;

            // The number of columns is always n + 1 (+ 1 for y): x^n-1, x^n-2, ..., x^n-(n-1), x^0 = y
            // Where x^0 is some unknown constant that will be solved and always holds coefficient of 1.
            // Which we can move to the last row (or assign to the last row).
            int rows = coordinates.Count;
            int columns = coordinates.Count + 1;
            matrix = new double[rows, columns];
            
            // Assign the values into the array's slots.
            // For each row (obtain the 1st dimension's length)
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Obtain the corresponding coordinate.
                Coordinate point = coordinates[i];
                int lastColumn = matrix.GetLength(1) - 1;
                // For each column
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    // In all other cases, insert the x value raised to its corresponding power.
                    // aka raised to n - index
                    int power = degree - j;
                    matrix[i, j] = Math.Pow(point.X, power);
                }
                // Finally insert the y-value at the last column index.
                matrix[i, lastColumn] = point.Y;
            }
            // Multiply a row by scalar mult.
            //Console.WriteLine($"Current matrix: {this}");
            //Console.WriteLine("Multiplying row 1 by -2.333: ");
            //RowMultiple(0, -2.3333);
            //Console.WriteLine($"Current matrix: {this}");
            //Console.WriteLine("Multiplying row 1 by -1/2.3333: ");
            //RowMultiple(0, (-1 / 2.3333));
            //Console.WriteLine($"Current matrix: {this}");

            // Add scalar mult to another row.

            //Console.WriteLine($"Current matrix: {this}");
            //Console.WriteLine("Adding row 0 by -2 to 1: ");
            //AddRowMultiple(1, 0, -2);
            //Console.WriteLine($"Current matrix: {this}");
            //Console.WriteLine("Multiplying by 0: ");
            //AddRowMultiple(1, 0, 0);
            //Console.WriteLine($"Current matrix: {this}");
            //AddRowMultiple(1, 0, 2);
            //Console.WriteLine($"Current matrix: {this}");
        }

        // Create a method that will return the row number for a given column if there exists some
        // entry with a coefficient of 1 (this will always return the first occurence).

        // The to string overwrite should return the solved matrix.
        public override string ToString()
        {
            string result = "[\n";
            string value;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += $"\t[";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    value = $"{matrix[i, j]}";
                    if (j < matrix.GetLength(1) - 1)
                    {
                        value += ", ";
                    }
                    result += value;
                }
                result += "],\n";
            }
            return $"{result}]";
        }

        // 3 Methods (operations according to the wiki).
        // Swap 2 rows in the matrix.
        private void SwapRows(int rowNumber1, int rowNumber2)
        {
            if (rowNumber1 == rowNumber2)
            {
                throw new InvalidRowSwapException($"Can't swap row #{rowNumber1} with row #{rowNumber2}, would result in 0s.");
            }
            // Or could we do in place swapping by setting a = a + b
            // b = a - b (thus a + b - b = a)
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                // Row 1 becomes the sum of itself + the value of row 2.
                matrix[rowNumber1, i] = matrix[rowNumber1, i] + matrix[rowNumber2, i];
                // Row 2 becomes the difference of the 2, resulting in the
                // original value of row1, cell i.
                matrix[rowNumber2, i] = matrix[rowNumber1, i] - matrix[rowNumber2, i];
                // Row 1 becomes the difference of the two again to result in
                // the original value of row 2, esentially swapping the two rows.
                matrix[rowNumber1, i] = matrix[rowNumber1, i] - matrix[rowNumber2, i];
            }
        }

        // Multiply a row by a non-zero scalar.
        private void RowMultiple(int rowNumber, double scalar)
        {
            if (scalar == 0)
            {
                throw new InvalidScalarMultipleException("Multiplying a row by 0 is not a valid operation.");
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[rowNumber, i] *= scalar;
            }
        }

        // 
        /// <summary>
        /// Add to one row a scalar multiple of another.
        /// </summary>
        /// <param name="rowNumber1">An int indicating the first row to which a scalar multiple of row two will be added</param>
        /// <param name="rowNumber2">An int indicating the second row that will be added to row 1.</param>
        /// <param name="scalar">A double that will be used to multiply row two with before adding it to row one.</param>
        private void AddRowMultiple(int rowNumber1, int rowNumber2, double scalar)
        {
            if (rowNumber1 == rowNumber2)
            {
                throw new InvalidRowAddition("Can not add the same rows.");
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[rowNumber1, i] += matrix[rowNumber2, i] * scalar;
            }
        }
    }
}
