using System;

namespace UniTests.SummerTests2021
{
    public class Task52ObnulenieMatrici : ITest
    {
        public int[,] CleanMatrix(int[,] matrix)
        {
            var len = matrix.GetUpperBound(0) + 1;
            var hight = matrix.GetUpperBound(1) + 1;
            var copyMatrix = new int[len, hight];
            Array.Copy(matrix, copyMatrix, matrix.Length);
            
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < hight; j++)
                {
                    if (0 != matrix[i, j]) 
                        continue;
                    
                    for (var k = 0; k < len; k++)
                    {
                        copyMatrix[i, k] = 0;
                        copyMatrix[k, j] = 0;
                    }
                }
            }

            return copyMatrix;
        }
        
        public void Run()
        {
            var len = 3;
            var hight = 3;
            var matrix = new [,]{{1, 0, 1}, {1, 1, 1}, {1, 1, 1}};
            
            Console.WriteLine($"input");
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < hight; j++)
                {
                    Console.Write($"{matrix[i,j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"outputs");
            var res = CleanMatrix(matrix);
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < hight; j++)
                {
                    Console.Write($"{res[i,j]}");
                }
                Console.WriteLine();
            }
        }
    }
}