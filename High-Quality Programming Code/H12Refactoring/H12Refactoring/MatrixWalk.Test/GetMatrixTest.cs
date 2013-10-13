using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixWalk.Test
{
   [TestClass]
    public class GetMatrixTest
    {
       [TestMethod]
       public void FindEmptyCell_ZeroMatrix()
       {

           int[,] expexted = new int[5, 5]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
         
            };

           int [,] result = MatrixWalk.GetMatrix(5);

          

          

       }

       private bool AreEqual (int[,] firstMatrix, int[,] secondMatrix)
       {
           for (int i = 0; i < firstMatrix.GetLength(0); i++)
			{
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    if (firstMatrix[i,j] != secondMatrix[i,j])
                    {
                        return false;
                    }
                }
			}
          
           return true;
       }
    }
}
