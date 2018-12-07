using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class MacLaurinPolynomial
    {
        private Operand expressionRoot;
        private int order;
        public List<Operand> MacLaurinPolynomials { get; private set; }

        public MacLaurinPolynomial(Operand expression, int n)
        {
            expressionRoot = expression;
            order = n;
            MacLaurinPolynomials = new List<Operand>();

            CreatePolynomials(expressionRoot, 0);
        }

        /// <summary>
        /// Is a recursive method that creates every i-th MacLaurin
        /// Polynomial based on the previous Polynomial (if there is one)
        /// and adds it into it's respective position in the list that holds
        /// all non-simplified Polynomials.
        /// </summary>
        /// <param name="expression">
        /// Is the original expression the user inserted into the program.
        /// </param>
        /// <param name="i">
        /// Is a counter that represents the current degree Polynomial
        /// </param>
        private void CreatePolynomials(Operand derivative, int i)
        {
            if (i <= order)
            {
                if (i == 0)
                {
                    // The 0 degree MacLaurin is always a constant if it exists.
                    // Thus we directly create the term and add it to the list.
                    MacLaurinPolynomials.Add(CreateMaclaurinTerm(derivative, i));
                    CreatePolynomials(derivative.Differentiate(), i + 1);
                }
                else
                {
                    // In all other cases, the MacLaurin polynomial consists of the previous
                    // MacLaurin polynomial plus the current term.
                    MacLaurinPolynomials.Add(CreateMacLaurinPolynomial(derivative, i));
                    
                    // Make a recursive call to the next.
                    CreatePolynomials(derivative.Differentiate(), i + 1);
                }
            }
        }

        /// <summary>
        /// Method that is responsible for creating the combination of the
        /// previous MacLaurin polynomial (i - 1) + the i-th term (constructing
        /// the ith degree MacLaurin polynomial).
        /// </summary>
        /// <param name="derivative"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private Operand CreateMacLaurinPolynomial(Operand derivative, int i)
        {
            Addition ploynomialRoot = new Addition();
            ploynomialRoot.LeftSuccessor = MacLaurinPolynomials[i - 1].Copy();
            ploynomialRoot.RightSuccessor = CreateMaclaurinTerm(derivative, i);
            return ploynomialRoot;
        }

        /// <summary>
        /// Method's sole purpose is to create the i-th MacLaurin polynomial term.
        /// </summary>
        /// <param name="expression">
        /// Requires an Operand, representing expression or a derrivative
        /// </param>
        /// <param name="i">An integer the i-th degree</param>
        /// <returns></returns>
        private Operand CreateMaclaurinTerm(Operand expression, int i)
        {
            // The zero-th order MacLaurin Polynomial is (P0(x)) = 
            // f(0) * (x^0)/0! which simplifies to a constant?
            if (i == 0)
            {
                // We can return calculate and return the function value
                // evaluated in x = 0.
                double functionValue = expression.Calculate(0);
                return new RealNumber(functionValue);
            }
            else
            {
                // The expression is differentiated if i != 0.
                // Calculate the coefficient in a = 0.
                double slope = expression.Calculate(0);
                // If the slope is NaN we pretty much evaluated all possible
                // derivatives (there is no more derivative possible)
                // Thus return 0 such that we can simplify later on.
                if (double.IsNaN(slope))
                {
                    slope = 0;
                }
                Operand resultSlope = new RealNumber(slope);

                Multiplication MacLaurinTerm = new Multiplication();
                MacLaurinTerm.LeftSuccessor = resultSlope;
                Division div = new Division();
                MacLaurinTerm.RightSuccessor = div;
                // Now create the right part of the multiplication (f'i(0) * (x - 0)^i / i!)
                // Create the numerator (x - 0)^i
                Power numerator = new Power();
                numerator.LeftSuccessor = new DependentVariableX();
                numerator.RightSuccessor = new Integer(i);
                // Create the denominator (i)!.
                Factorial denominator = new Factorial();
                denominator.LeftSuccessor = new Integer(i);
                // Add the numerator and denominator into the division Operator.
                div.LeftSuccessor = numerator;
                div.RightSuccessor = denominator;

                return MacLaurinTerm;
            }
        }
    }
}
