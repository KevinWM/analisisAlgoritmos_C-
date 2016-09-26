using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    class Dijkstra
    {
       
        // Declaración de variables a utilizar
        public int rango = 0;
        public int[,] L; // matriz de adyacencia
        public int[] C; // arreglo de nodos
        public int[] D; // arreglo de distancias
        public int trango = 0;

        // Algoritmo Dijkstra
        public Dijkstra(int paramRango, int [ , ] paramArreglo)
        {
            L = new int [paramRango, paramRango];
            C = new int [paramRango];
            D = new int [paramRango];
            rango = paramRango;

            for( int i = 0; i < rango; i++)
            {
                for( int j = 0; j < rango; j++)
                {
                    L[i, j] = paramArreglo[i, j];
                }
            }
            for( int i = 0; i < rango; i++)
            {
                C[i] = i;
            }
            C[0] = 99;

            for (int i = 1; i < rango; i++)
            {
                D[i] = L[0, i];
            }
        }

        // Rutina de solución Dijkstra
        public void SolDijkstra( )
        { 
            int minValor = Int32.MaxValue;
            int minNodo = 0;
            
            for( int i = 0; i < rango; i++)
            {   
                if(C[i] == 99)
                    continue;
                
                if(D[i] > 0 && D[i] < minValor)
                {
                    minValor = D[i];
                    minNodo = i;
                }
            }
            C[minNodo] = 99;

            for( int i = 0; i < rango; i++)
            {
                if(L[minNodo, i] < 0) // si no existe arco
                    continue;
                
                if(D[i] < 0) // si no hay un peso asignado
                {
                    D[i] = minValor + L[minNodo, i];
                    continue;
                }
                
                if((D[minNodo] + L[minNodo, i]) < D[i])
                    D[i] = minValor+ L[minNodo, i];
            }
        }
        
        // Función de implementación del algoritmo
        
        public void CorrerDijkstra( )
        {
            for(trango = 1; trango < rango; trango++)
            {
                SolDijkstra( );
               // Console.WriteLine("Iteracion No." + trango);
               // Console.WriteLine("Matriz de distancias: ");
                
                for( int i = 0; i < rango; i++)
                  //  Console.Write(i + " ");
                
                Console.WriteLine(" ");

                for (int i = 0; i < rango; i++) { }
                    //Console.Write(D[i] + " ");
                
                //Console.WriteLine(" ");
                //Console.WriteLine(" ");
            }
        }
    }
}
