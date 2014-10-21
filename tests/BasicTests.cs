using System;
using NUnit.Framework;

namespace Tests2Matrix
{
    [TestFixture()]
    public class BasicTests
    {
        [Test()]
        public void MatrixInitialization()
        {
            var a = new Matrix<double>() { { 10, 1, 3 }, { 4, 5, 7 } };
            Assert.AreEqual(2, a.Rows);
            Assert.AreEqual(3, a.Cols);
            Assert.AreEqual(10, a[0, 0]);
            Assert.AreEqual(7, a[1, 2]);
        }

        [Test()]
        public void MatrixResizing()
        {
            var a = new Matrix<double> { { 10, 1, 3 }, { 4, 5, 7 } };
            a.Add(5, 10, 15);
            Assert.AreEqual(3, a.Rows);
            a.Rows++;
            a.Cols++;
            Assert.AreEqual(default(double), a[3, 3]);
            Assert.AreEqual(10, a[2, 1]);
            var resized = new Matrix<double> { { 10, 1, 3, 0 }, { 4, 5, 7, 0 }, { 5, 10, 15, 0 }, { 0, 0, 0, 0 } };
            Assert.IsTrue(resized.Equals(a));
            a.Cols -= 2;
            var shrinked1 = new Matrix<double> { { 10, 1 }, { 4, 5 }, { 5, 10 }, { 0, 0 } };
            Assert.IsTrue(shrinked1.Equals(a));
            a.Rows -= 3;
            var shrinked2 = new Matrix<double> { { 10, 1 } };
            Assert.IsTrue(shrinked2.Equals(a));
        }


        /// <summary>
        /// Multiplication:
        /// - http://www.mttlr.org/voltwo/scheq1.gif
        /// - http://www.mttlr.org/voltwo/scheq2.gif
        /// </summary>
        [Test()]
        public void MatrixOperators()
        {
            var a = new Matrix<double>() { { 10, 1, 3 }, { 4, 5, 7 } };
            var b = new Matrix<double>() { { 1, 1, 1 }, { 2, 2, 2 } };
            var c = new Matrix<double>() { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var summed = new Matrix<double>() { { 11, 2, 4 }, { 6, 7, 9 } };
            Assert.IsTrue(summed.Equals(a + b));
            var multiplied = new Matrix<double>() { { 28, 42 }, { 54, 70 } };
            Assert.IsTrue(multiplied.Equals(a * c));
        }
    }
}
