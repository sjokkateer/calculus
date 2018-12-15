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
            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(1, 3),
            //    new Coordinate(2, 5) };

            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(2, 1),
            //    new Coordinate(3, 1),
            //    new Coordinate(4, 3) };

            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(1, 1) };


            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(1, 1),
            //    new Coordinate(2, 1),
            //    new Coordinate(3, 1),
            //    new Coordinate(4, 1) };

            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(-3, 3),
            //    new Coordinate(-2.31, 5.32),
            //    new Coordinate(0, 0),
            //    new Coordinate(1, 3),
            //    new Coordinate(2, 6) };

            //List<Coordinate> coordinates = new List<Coordinate>() {
            //    new Coordinate(0, 1),
            //    new Coordinate(1, 3),
            //    new Coordinate(2, 6) };

            List<Coordinate> coordinates = new List<Coordinate>() {
                new Coordinate(0, 1),
                new Coordinate(1, 3) };

            //SystemSolver solver = new SystemSolver(coordinates);
            //SystemSolver solver2 = new SystemSolver(coordinates);
            SystemSolver solver3 = new SystemSolver(coordinates);
            //SystemSolver solver4 = new SystemSolver(coordinates);
            //SystemSolver solver5 = new SystemSolver(coordinates);
            Console.WriteLine($"Matrix of degree {solver3.Degree}\n{solver3}");
            Console.ReadKey();
        }
    }
}
