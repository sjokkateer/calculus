using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace eXpressionParsing
{
    class SystemSolver
    {
        // The system solver takes in a 2D (square) array of doubles? 
        // [(x, y) ordered pairs -> input into the array upon construction].
        private double[,] matrix;
        public int Degree { get; }
        public double[,] Matrix
        {
            get { return matrix.Clone() as double[,]; }
        }

        // For n points, the polynomial will be of degree/order n - 1.
        // Need a constructor that takes a list of coordinates.
        public SystemSolver(List<Coordinate> coordinates)
        {
            // For now we assume that the input will result in a proper
            // entry that results in a n - 1 order polynomial and that the number
            // of coordinates entered is >= 2.
            Degree = coordinates.Count - 1;

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
                    int power = Degree - j;
                    matrix[i, j] = Math.Round(Math.Pow(point.X, power), 2);
                }
                // Finally insert the y-value at the last column index.
                matrix[i, lastColumn] = Math.Round(point.Y, 2);
            }
            SolveMatrix();
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

        /// <summary>
        /// Purpose is to reduce the matrix into reduced row echelon form.
        /// 
        /// Will immediately be called inside the constructor of the solver class.
        /// </summary>
        private void SolveMatrix()
        {
            // Use operation (3) to add to one row a scalar mult of another
            // to reduce all other column entries to 0.
            // Use operation (2) multiply the row by scalar mult to get the
            // leading co-efficient to be 1.

            // To achieve this we can iterate over all rows
            // And for every row we can iterate over all columns
            // The leading coefficient always residing in the cell where row# == column#

            // We can simply obtain the scalar multiple by dividing the coefficient of the
            // other non leading coefficient by the leading. thus if we start with
            // matrix[0, 0], then -(matrix[1, 0] / matrix[0, 0]) is the scalar multiple to
            // cancel out that row.

            // Square matrix, where i should be used for the columns
            double scalar;
            int counter;
            for (int i = 0; i <= Degree; i++)
            {
                // Counter should always start at a row lower than i, since row i could
                // already be solved or in it's echelon form.
                counter = i + 1;
                // If the current value in matrix[i, i] = 0, we have to swap it
                // with a row that does have a value != 0 in [j, i]
                while (matrix[i, i] == 0 && counter <= Degree)
                {
                    // Swap rows i with counter as long as counter <= degree
                    SwapRows(i, counter);
                    counter++;
                }

                // If we exhausted all we should move to the next row/column actually.
                // Since this would indicate that all values in column i were 0.
                if (matrix[i, i] == 0)
                {
                    break;
                }

                // And j should be used for the rows
                for (int j = 0; j <= Degree; j++)
                {
                    // Reduce all values above and below i == j to have a coefficient of 0.
                    if (j != i)
                    {
                        // Add to row j a scalar multiple of row i
                        scalar = -(matrix[j, i] / matrix[i, i]);
                        AddRowMultiple(j, i, scalar);
                    }
                }
            }
            // Because of the above process, all cells have a 0 value except for the diagonal.
            // This means we have to loop once through all diagonal cells and multiply to get
            // a 1 coefficient. and thus our final result.
            for (int i = 0; i <= Degree; i++)
            {
                // Make the coefficients of the diagonal = 1.
                scalar = 1 / (matrix[i, i]); // equivalent to a/a = 1
                RowMultiple(i, scalar);
            }
        }
    }
}
