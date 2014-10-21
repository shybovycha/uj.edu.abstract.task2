using System;
using Tests2Matrix;

namespace abstract_task2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var a = new Matrix<double>() { { 10, 1, 3 }, { 4, 5, 7 } };
            var b = new Matrix<double>() { { 1, 1, 1 }, { 2, 2, 2 } };
            var c = new Matrix<double>() { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var summed = new Matrix<double>() { { 11, 2, 4 }, { 6, 7, 9 } };
            var d = a + b;
            var multiplied = new Matrix<double>() { { 28, 42 }, { 54, 70 } };
            var e = a * c;

            Console.WriteLine("a + b == d?: {0}", summed.Equals(d));
            Console.WriteLine("a * c == e?: {0}", multiplied.Equals(e));
        }
    }
}
