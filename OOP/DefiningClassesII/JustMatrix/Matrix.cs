////
namespace JustMatrix
{
    using System;
    using System.Linq;

    public class Matrix<T>
        where T : IComparable
    {
       private uint rows;
       private uint cols;
       private T[,] matrix;

       public Matrix(uint rows, uint cols)
       {
           if (rows == 0)
           {
               throw new ArgumentException("The value for rows can not be zero.");
           }

           if (rows == 0)
           {
               throw new ArgumentException("The value for cols can not be zero.");
           }

           this.rows = rows;
           this.cols = cols;
           this.matrix = new T[rows, cols];
       }

       #region properties
       public uint Rows
        {
            get { return this.rows; }
           //// set { myVar = value; }
        }

       public uint Cols
        {
            get { return this.cols; }
            //// set { myVar = value; }
        }
       #endregion

       #region indexer
       public T this[int row, int col] 
        {
            get
            {
                if (row >= 0 && row < this.rows)
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (row >= 0 && row < this.rows)
                {
                    this.matrix[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
       #endregion

       #region overloads
       public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            Matrix<T>.Check(firstMatrix);
            Matrix<T>.Check(secondMatrix);

            if (firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
            {
                throw new InvalidOperationException("The Matrices must be with equal size.");
            }
            else
            {
                Matrix<T> newMatrix = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);

                for (int row = 0; row < newMatrix.rows; row++)
                {
                    for (int col = 0; col < newMatrix.cols; col++)
                    {
                        newMatrix[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                    }
                }

                return newMatrix;
            }
        }

       public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            Matrix<T>.Check(firstMatrix);
            Matrix<T>.Check(secondMatrix);

            if (firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
            {
                throw new InvalidOperationException("The Matrices must be with equal size.");
            }
            else
            {
                Matrix<T> newMatrix = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);

                for (int row = 0; row < newMatrix.rows; row++)
                {
                    for (int col = 0; col < newMatrix.cols; col++)
                    {
                        newMatrix[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                    }
                }

                return newMatrix;
            }
        }

       public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            Matrix<T>.Check(firstMatrix);
            Matrix<T>.Check(secondMatrix);

            if (firstMatrix)
            {
                throw new NullReferenceException("There are objects null in the firstMatrix or the matrix does not contain non-zero elements, or value for the columns or rows is zero.");
            }

            if (secondMatrix)
            {
                throw new NullReferenceException("There are objects null in the secondMatrix or the matrix does not contain non-zero elements, or value for the columns or rows is zero.");
            }

            if (firstMatrix.cols == secondMatrix.rows)
            {
                return Multiplication(firstMatrix, secondMatrix);
            }
            else
            {
                throw new InvalidOperationException("The number of columns of fisrt matrix must equal the number of rows of the second matrix");
            }          
        }

       public static Matrix<T> operator *(Matrix<T> firstMatrix, T number)
        {
            Matrix<T>.Check(firstMatrix);
            
            if (firstMatrix)
            {
                throw new NullReferenceException("There are objects null in the firstMatrix or the matrix does not contain non-zero elements, or value for the columns or rows is zero.");
            }
                
            return Multiplication(firstMatrix, number);                    
        }

       public static bool operator true(Matrix<T> matrix)
       {
           //// allZeroMatrix 

           for (int row = 0; row < matrix.rows; row++)
           {
               for (int col = 0; col < matrix.cols; col++)
               {
                   if ((dynamic)matrix[row, col] != 0)
                   {
                       return false;
                   }
               }
           }

           return true;
       }

       public static bool operator false(Matrix<T> matrix)
       {
           if (matrix)
           {
               return true;
           }

           return false;
       }     
       #endregion

       #region methods
       private static Matrix<T> Multiplication(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
       {
           Matrix<T> newMatrix = new Matrix<T>(firstMatrix.rows, secondMatrix.cols);

           for (int row = 0; row < newMatrix.rows; row++)
           {
               for (int col = 0; col < newMatrix.cols; col++)
               {
                   for (int colFM = 0, rowSM = 0; colFM < firstMatrix.cols; colFM++, rowSM++)
                   {
                       newMatrix[row, col] += (dynamic)firstMatrix[row, colFM] * (dynamic)secondMatrix[rowSM, col];
                   }
               }
           }

           return newMatrix;
       }

       private static Matrix<T> Multiplication(Matrix<T> matrix, T number)
       {
           Matrix<T> newMatrix = new Matrix<T>(matrix.rows, matrix.cols);

           for (int row = 0; row < newMatrix.rows; row++)
           {
               for (int col = 0; col < newMatrix.cols; col++)
               {
                   newMatrix[row, col] = (dynamic)matrix[row, col] * (dynamic)number;
               }
           }

           return newMatrix;
       }

       private static void Check(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new NullReferenceException("The value of tha matrix should not be null");
            }

            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.cols; col++)
                {
                    if (matrix[row, col] == null)
                    {
                        throw new NullReferenceException("The matrix should not contain objects with value null.");
                    }
                }
            }
        }
       #endregion
    }
}
