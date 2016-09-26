using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    class floyd
    {
        public int[,] dist;

        public floyd() 
        {
            
        } 

        public int[,] FloydAlgorithm(int[,] Matrix)
        {
            int N = Matrix.GetLength(0);
            dist = Matrix;
            int i, j, k;

            for (k = 0; k < N; k++)
                for (i = 0; i < N; i++)
                    for (j = 0; j < N; j++)
                        if (dist[i, j] != -1 && dist[i, k] != -1 && dist[k, j] != -1)
                        {
                            dist[i, j] = Min(dist[i, j], dist[i, k] + dist[k, j]);
                        }

            // El resultado es la distancia mas corta entre i y j y se ve en dist[i][j].            
            return dist;
        }

        public int Min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public void PrintMatrix(int[,] Matrix)
        {
            for (int x = 0; x < Matrix.GetLength(0); x++)
            {
                for (int y = 0; y < Matrix.GetLength(0); y++)
                {

                    Console.Write(String.Format("{0,5:0}", Matrix[x, y]));
                }
                Console.WriteLine();
            }
        } 

    }
}
