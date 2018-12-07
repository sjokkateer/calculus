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
        private List<Operand> macLaurinTerms;

        public MacLaurinPolynomial(Operand expression, int n)
        {
            expressionRoot = expression;
            order = n;
            macLaurinTerms = new List<Operand>();

            // Call the creation of self.
            Create(expressionRoot.Copy(), 0);
        }

        private void Create(Operand expression, int i)
        {
            if (i == order)
            {
                // Terminate the recursive method calls.
                macLaurinTerms.Add(CreateMaclaurinTerm(expression, i));
            }
            else
            {
                // Create current term, add it to the list, and pass on the derivative to the next call.
                macLaurinTerms.Add(CreateMaclaurinTerm(expression, i));
                Create(expression.Differentiate(), i);
            }
        }

        /// <summary>
        /// Method's sole purpose is to create the ith MacLaurin polynomial term.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="i"></param>
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

        /// <summary>
        /// Returns the n-th MacLaurinPolynomial if it exists.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Operand GetMacLaurinPolynomial(int n)
        {
            if ((n >= 0) && (n <= order))
            {
                Operand macLaurinPolynomial = macLaurinTerms[0];
                if (n == 0)
                {
                    return macLaurinPolynomial;
                }
                else
                {
                    // We have at least more than 1 term to take care 
                    // of thus need the addition operator.
                    Addition add = new Addition();
                    Operand termI;
                    for (int i = 0; i <= order; i++)
                    {
                        // Pick up the i-th term
                        termI = macLaurinTerms[i];
                        if (i == n)
                        {
                            // In case this is the last term we add that term to 
                            // the right of the current addition object as a wrap up.
                            add.RightSuccessor = termI;
                        }
                        else
                        {
                            // Otherwise this is not the last
                            add.LeftSuccessor = termI;
                            add.RightSuccessor = new Addition();
                            add = (Addition)add.RightSuccessor;
                        }
                    }
                }
                return macLaurinPolynomial;
            }
            return null;
        }
    }
}
