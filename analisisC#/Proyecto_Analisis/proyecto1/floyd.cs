using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace proyecto1
{
    class floyd
    {
        public int[,] dist;
        public Int64 comparacionesF = 0;
        public Int64 asignacionesF = 0;
        public Int64 cantLineasF = 0;
        public Int64 comparacionesC = 0;
        public Int64 asignacionesC = 0;
        public Int64 cantLineasC = 0;
        public LinkedList<int> rutaF = new LinkedList<int>();
        public int distancia = 0;
        public string ruta; 

        public floyd() 
        {
            
        } 

        public int[,] correrfloyd(int[,] Matrix)
        {
            Stopwatch tiempo;
            tiempo = Stopwatch.StartNew();
            int N = Matrix.GetLength(0);                                                        cantLineasF += 3;
            dist = Matrix;                                                                      asignacionesF += 2;
            int i, j, k;

            for (k = 0; k < N; k++) 
            {
                                                                                                cantLineasF += 2;
                for (i = 0; i < N; i++)
                {
                                                                                                cantLineasF += 2;
                    for (j = 0; j < N; j++) 
                    {
                                                                                                cantLineasF += 3;
                        if (dist[i, j] != 0 && dist[i, k] != 0 && dist[k, j] != 0)
                        {
                            cantLineasF++;
                            dist[i, j] = min(dist[i, j], dist[i, k] + dist[k, j]);              asignacionesF++;
                        }                                                                       comparacionesF += 2; asignacionesF++;
                    }                                                                           comparacionesF++; asignacionesF++;
                }                                                                               comparacionesF++; asignacionesF++;
            }
                                                                                                cantLineasF++;
            return dist;
        }


        public int min(int a, int b)
        {
                                                                                                comparacionesF++; cantLineasF++;
            if (a < b)                                                                          
            {
                                                                                                cantLineasF++;
                return a;
            }  
            else
            {
                                                                                                cantLineasF += 2;
                return b;
            }
        }
        public void rutaCor(vertice tempVertice)
        {
            vertice tempV = tempVertice;

            while (true)
            {
                ruta = ruta + tempV.numero + ", "; comparacionesC++; asignacionesC++;                                                                   
                if (tempV.sigV == null) {
                    comparacionesC++;
                    return;
                }
                else if(tempV.sigV.sigV == null)
                {
                    distancia += tempV.sigA.distancia;
                    tempV = tempV.sigV; comparacionesC += 2; asignacionesC += 2; cantLineasC += 5;
                }
                
                else if (tempV.sigV.sigA.sigA == null)
                {
                    if (tempV.sigA.sigA.distancia < (tempV.sigA.distancia + tempV.sigV.sigA.distancia))
                    {
                        distancia += tempV.sigA.sigA.distancia;
                        tempV = tempV.sigV.sigV; comparacionesC += 4; asignacionesC += 2; cantLineasC += 7;
                    }
                    else
                    {
                        distancia += tempV.sigA.distancia;
                        tempV = tempV.sigV; comparacionesC += 3; asignacionesC += 2; cantLineasC += 7;
                    }
                }

                else if (tempV.sigA.sigA.distancia < (tempV.sigA.distancia + tempV.sigV.sigA.distancia))
                {

                    if ((tempV.sigA.distancia + tempV.sigV.sigA.sigA.distancia) <= (tempV.sigA.sigA.distancia + tempV.sigV.sigV.sigA.distancia))
                    {
                        distancia += tempV.sigA.distancia;
                        tempV = tempV.sigV; comparacionesC += 5; asignacionesC += 2; cantLineasC += 8;
                    }
                    else
                    {
                        distancia += tempV.sigA.sigA.distancia;
                        tempV = tempV.sigV.sigV; comparacionesC += 4; asignacionesC += 2; cantLineasC += 8;
                    }
                }
                else
                {
                    distancia += tempV.sigA.distancia;
                    tempV = tempV.sigV; comparacionesC += 4; asignacionesC += 2; cantLineasC += 8;
                }
            }
        }

    }
}
