using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    class dijkstra
    {
        // Declaración de variables a utilizar
        public int rango = 0;
        public int[,] L; // matriz de adyacencia
        public int[] C; // arreglo de nodos
        public int[] D; // arreglo de distancia
        public int trango = 0;
        public int comparacionesD = 0;
        public int asignacionesD = 0;
        public int cantLineasD = 0;
        
        

        // Algoritmo Dijkstra
        public dijkstra(int paramRango, int [ , ] paramArreglo)
        {
            L = new int[paramRango, paramRango];                        cantLineasD += 4;
            C = new int [paramRango];
            D = new int [paramRango];
            rango = paramRango;

            for (int i = 0; i < rango; i++)
            {
                                                                        cantLineasD += 2;
                for( int j = 0; j < rango; j++)
                {
                    L[i, j] = paramArreglo[i, j];                       cantLineasD += 3;
                }
            }
            for( int i = 0; i < rango; i++)
            {
                C[i] = i;
            }
            C[0] = 99999;

            for (int i = 1; i < rango; i++)
            {
                                                                        cantLineasD += 3;
                D[i] = L[0, i];
            }
        }

        // Rutina de solución Dijkstra
        public void solucionDijkstra( )
        {
            int minValor = Int32.MaxValue;                              cantLineasD += 2;
            int minNodo = 0;                                            asignacionesD += 2;

            for( int i = 0; i < rango; i++)
            {
                if (C[i] == 99999)
                {
                                                                        cantLineasD++;
                    continue;
                }
                if(D[i] > 0 && D[i] < minValor)
                {
                    minValor = D[i];                                    cantLineasD += 2;
                    minNodo = i;                                        asignacionesD += 2;
                }                                                       comparacionesD += 4; asignacionesD++; cantLineasD += 3;
            }
            C[minNodo] = 99999;                                         asignacionesD++; cantLineasD += 2;

            for( int i = 0; i < rango; i++)
            {
                if (L[minNodo, i] < 0) // si no existe arco
                {
                                                                        asignacionesD++;
                    continue;
                }
                
                if(D[i] < 0) // si no hay un peso asignado
                {
                    D[i] = minValor + L[minNodo, i];                    asignacionesD += 2;
                    continue;
                }

                if ((D[minNodo] + L[minNodo, i]) < D[i])
                {
                    D[i] = minValor + L[minNodo, i];                    asignacionesD++;
                }                                                       comparacionesD += 4; asignacionesD++; cantLineasD += 5;
            }
        }
        
        // Función de implementación del algoritmo
        
        public void correrDijkstra( )
        {
            for(trango = 1; trango < rango; trango++)
            {
                solucionDijkstra();                                     comparacionesD++; asignacionesD++; cantLineasD += 3;           
            }
        }
    }
}
