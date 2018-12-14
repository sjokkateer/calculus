using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsOfEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Coordinate> coordinates = new List<Coordinate>() {
                new Coordinate(1, 3),
                new Coordinate(2, 5) };

            List<Coordinate> coordinates2 = new List<Coordinate>() {
                new Coordinate(2, 1),
                new Coordinate(2, 2),
                new Coordinate(3, 3) };
            
            SystemSolver solver = new SystemSolver(coordinates);
            SystemSolver solver2 = new SystemSolver(coordinates2);

            Console.ReadKey();
        }
    }
}
