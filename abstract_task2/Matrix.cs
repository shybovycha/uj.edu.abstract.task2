using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests2Matrix
{
    public class Matrix<T> : IEquatable<Matrix<T>>, IEnumerable<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        protected List<List<T>> elements;

        public Matrix()
        {
            elements = new List<List<T>>();
        }
       
        public bool Equals(Matrix<T> other)
        {
            if (Rows != other.Rows || Cols != other.Cols)
                return false;

            for (int i = 0; i < Rows; i++) {
                for (int t = 0; t < Cols; t++) {
                    if ((dynamic) this[i, t] != (dynamic) other[i, t]) {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Add(params T[] row) 
        {
            List<T> newRow = new List<T>(row);
            elements.Add(newRow);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (List<T> row in elements) {
                foreach (T elt in row) {
                    yield return elt;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Rows 
        { 
            get 
            { 
                return elements.Count; 
            }

            set 
            {
                while (elements.Count < value) {
                    List<T> row = new List<T>();

                    for (int i = 0; i < Cols; i++)
                        row.Add(default(T));

                    elements.Add(row);
                }

                while (elements.Count > value) {
                    elements.RemoveAt(elements.Count - 1);
                }
            }
        }

        public int Cols 
        {
            get 
            {
                if (elements.Count < 1)
                    return 0;

                return elements.First().Count; 
            }

            set 
            {
                for (int i = 0; i < Rows; i++) {
                    while (elements[i].Count < value)
                        elements[i].Add(default(T));

                    while (elements[i].Count > value)
                        elements[i].RemoveAt(elements[i].Count - 1);
                }
            }
        }

        public T this[int row, int column]
        {
            get 
            {
                return elements[row][column];
            }

            set 
            {
                if (row < 0 || column < 0)
                    return;

                if (row > Rows - 1)
                    Rows = row + 1;

                if (column > Cols - 1)
                    Cols = column + 1;

                elements[row][column] = value;
            }
        }

        public static Matrix<T> operator+(Matrix<T> a, Matrix<T> b)
        {
            Matrix<T> result = new Matrix<T>();

            for (int i = 0; i < a.Rows; i++) {
                for (int t = 0; t < a.Cols; t++) {
                    result[i, t] = (dynamic) a[i, t] + (dynamic) b[i, t];
                }
            }

            return result;
        }

        public static Matrix<T> operator*(Matrix<T> a, Matrix<T> b)
        {
            Matrix<T> result = new Matrix<T>();

            if (a.Rows != b.Cols)
                return result;

            for (int i = 0; i < a.Rows; i++) {
                for (int t = 0; t < b.Cols; t++) {
                    T sum = default(T);

                    for (int j = 0; j < a.Cols; j++) {
                        sum += (dynamic) a[i, j] * (dynamic) b[j, t];
                    }

                    result[i, t] = sum;
                }
            }

            return result;
        }
    }
}
