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
        private double[,] matrix;
        public int Degree { get; }
        public double[,] Matrix
        {
            // Returns a copy of the solved matrix.
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
                    matrix[i, j] = Math.Pow(point.X, power);
                }
                // Finally insert the y-value at the last column index.
                matrix[i, lastColumn] = point.Y;
            }
            // The method responsible for inplace solving.
            // This causes side effects
            SolveMatrix();
        }

        /// <summary>
        /// Will return the matrix as a two dimensional matrix:
        ///     [
        ///         [a, b, c],
        ///         [d, e, f],
        ///     ]
        /// </summary>
        /// <returns>A string representation of the solved matrix.</returns>
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
        /// <summary>
        /// Method that swaps row having rownumber 1 with row having rownumber 2.
        /// 
        /// If both row numbers are the same, the method will throw an exception, not allowing such operation.
        /// </summary>
        /// <param name="rowNumber1">An integer representing the row's index, starting at 0.</param>
        /// <param name="rowNumber2">An integer representing the row's index, starting at 0.</param>
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

        /// <summary>
        /// Multiply a row by a non-zero scalar.
        /// </summary>
        /// <param name="rowNumber">An integer representing the row's index, starting at 0</param>
        /// <param name="scalar">A double, representing the value that is used to multiply the row's values by.</param>
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

        /// <summary>
        /// Is a wrapper method that will initiate the recursive calls
        /// to obtain the polynomial such that the user does not have
        /// to insert the degree every time.
        /// </summary>
        /// <returns>The expression root for the polynomial that is constructed based on the solution of the system of equations.</returns>
        public Operand GetPolynomial()
        {
            return MatrixToExpression(Degree);
        }

        /// <summary>
        /// Recursive implementation of creating the polynomial.
        /// 
        /// Will make a call at the highest degree (which will be at the front of the expression)
        /// and move to lower terms until it reaches the 0th term, aka the cosntant and returns
        /// back up the stack.
        /// </summary>
        /// <param name="degree">An integer, the dynamic degree that is decremented by one each recursive call.</param>
        /// <returns>The expression root for the polynomial that is constructed based on the solution of the system of equations.</returns>
        private Operand MatrixToExpression(int degree)
        {
            if (degree == 0)
            {
                return CreatePolynomialTerm(matrix[Degree - degree, Degree + 1], degree);
            }
            else
            {
                // Degree is higher than 0, thus we always have an addition of terms.
                // thus we create the current term and recursively obtain the other terms.
                Addition termsAdded = new Addition();
                termsAdded.LeftSuccessor = CreatePolynomialTerm(matrix[Degree - degree, Degree + 1], degree);
                termsAdded.RightSuccessor = MatrixToExpression(degree - 1);
                return termsAdded;
            }
        }

        /// <summary>
        /// Method solely responsible for creating the i-th term
        /// of the polynomial that the system represented.
        /// </summary>
        /// <param name="coefficient">A double, representing the coefficient of the i-th term.</param>
        /// <param name="degree">An integer, representing the order (x^degree) term.</param>
        /// <returns></returns>
        private Operand CreatePolynomialTerm(double coefficient, int degree)
        {
            Multiplication term = new Multiplication();
            term.LeftSuccessor = new RealNumber(coefficient);

            // Create a power of x for the right side.
            Power xRaisedToDegree = new Power();
            xRaisedToDegree.LeftSuccessor = new DependentVariableX();
            xRaisedToDegree.RightSuccessor = new Integer(degree);
            term.RightSuccessor = xRaisedToDegree;

            return term;
        }
    }
}
