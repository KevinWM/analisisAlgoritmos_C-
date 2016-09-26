//Kevin Walsh Muñoz
//Jonathan Rojas Vargas
//Fecha inicio  17/09/2014
//Fecha final   01/10/2014



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace proyecto1
{
    public class Program
    {
        static public vertice primerVertice = new vertice();

        static public Random r = new Random();
        static public int cantVertices = 5;
        static public int[,] matrizValores;
        static public int[,] matrizFloyd;
        static public float tiempoT;


        static void Main(string[] args)
        {
            primerVertice = null;
            
            crearGrafo();
            crearMatriz();
            crearMatrizFloyd();

            Stack pila2 = new Stack(); ;
            Stopwatch tiempo;

            tiempo = Stopwatch.StartNew();
            dijkstra prueba1 = new dijkstra((int)Math.Sqrt(matrizValores.Length), matrizValores);
            prueba1.correrDijkstra();
            tiempoT = tiempo.ElapsedMilliseconds;

            Console.WriteLine("La solucion de la ruta mas corta en Dijkstra es : " + prueba1.D[cantVertices - 1]);
            Console.WriteLine("\r\n" + "Asignaciones Dijkstra: " + prueba1.asignacionesD + "\r\n" + "Comparaciones Dijkstra: " + prueba1.comparacionesD);
            Console.WriteLine("\r\n" + "Tiempo ejecucion: " + tiempoT + " Milisegundos");
            Console.WriteLine("\r\n" + "Cantidad de lineas ejecutadas: " + prueba1.cantLineasD + "\r\n");
            int nodo = 1;
            foreach (int i in prueba1.D)
            {
                Console.Write("Distancia minima a nodo " + nodo + " es ");
                Console.WriteLine(i);
                nodo++;
            }
            Console.WriteLine("\r\n" + "--------------------------------------------------------------------------------");

            
            floyd prueba2 = new floyd();

            matrizFloyd = prueba2.correrfloyd(matrizFloyd);
            tiempo = Stopwatch.StartNew();
            prueba2.rutaCor(primerVertice);
            tiempoT = tiempo.ElapsedMilliseconds;

            Console.WriteLine("\r\n" + "La solucion de la ruta mas corta en Floyd es : " + matrizFloyd[0, cantVertices - 1]);
            Console.WriteLine("\r\n" + "Asignaciones Floyd: " + prueba2.asignacionesF + "\r\n" + "Comparaciones Floyd: " + prueba2.comparacionesF);
            Console.WriteLine("\r\n" + "Tiempo ejecucion: " + tiempoT + " Milisegundos");
            Console.WriteLine("\r\n" + "Cantidad de lineas ejecutadas: " + prueba2.cantLineasF + "\r\n");
           
            for (int x = 0; x < prueba2.dist.GetLength(0); x++)
            {
                for (int y = 0; y < prueba2.dist.GetLength(0); y++)
                {
                    if (prueba2.dist[x, y] == 99999)
                    {
                        Console.Write(String.Format("{0,5:0}", "++"));
                    }
                    else 
                    {
                        Console.Write(String.Format("{0,5:0}", prueba2.dist[x, y]));
                    }
                    
                }
                Console.WriteLine();
            }

            Console.WriteLine("\r\n" + "--------------------------------------------------------------------------------");

            Console.WriteLine("\r\n" + "La solucion de la ruta mas corta con el Iterativo es : " + prueba2.distancia);
            Console.WriteLine("\r\n" + "Asignaciones Iterativo: " + prueba2.asignacionesC + "\r\n" + "Comparaciones Iterativo: " + prueba2.comparacionesC);
            Console.WriteLine("\r\n" + "Tiempo ejecucion: " + tiempoT + " Milisegundos");
            Console.WriteLine("\r\n" + "Cantidad de lineas ejecutadas: " + prueba2.cantLineasC);
            Console.WriteLine("\r\n" + "Ruta mas corta: " + prueba2.ruta);
            Console.WriteLine("\r\n" + "--------------------------------------------------------------------------------");

            recursivo prueba3 = new recursivo();
            tiempo = Stopwatch.StartNew();
            prueba3.rutaCorta(primerVertice, 0, "");
            tiempoT = tiempo.ElapsedMilliseconds;
            Console.WriteLine("\r\n" + "La solucion de la ruta mas corta en el metodo Recursivo es : " + prueba3.distanciaCorta);
            Console.WriteLine("\r\n" + "Asignaciones Recursivo: " + prueba3.asignacionesR + "\r\n" + "Comparaciones Recursivo: " + prueba3.comparacionesR);
            Console.WriteLine("\r\n" + "Tiempo ejecucion: " + tiempoT + " Milisegundos");
            Console.WriteLine("\r\n" + "Cantidad de lineas ejecutadas: " + prueba3.cantLineasR);
            Console.WriteLine("\r\n" + prueba3.ruta);
            Console.WriteLine("\r\n" + "--------------------------------------------------------------------------------");
            //foreach (Object obj in prueba3.pila)
            //{
            //    Console.Write("    {0}", obj);
            //}

            //for (int i = 1; i < prueba1.D.Length; i++)
            //{
            //    Console.Write(i + "= " + prueba1.D[i] + ", ");
            //}

                Console.ReadKey();
        }

        static public void imprimir()
        {
            vertice tempV = primerVertice;
            arco tempA;

            while (tempV != null)
            {
                Console.Write("---------------------" + "\r\n");
                Console.Write("Vertice " + tempV.numero + "\r\n");
                tempA = tempV.sigA;
                while (tempA != null)
                {
                    Console.Write("Ruta " + tempA.destino.numero + " distancia " + tempA.distancia + "\r\n");
                    tempA = tempA.sigA;
                }
                tempV = tempV.sigV;
            }
        }

        static public void crearGrafo() 
        {
            for (int i = 1; i <= cantVertices; i++ )
            {
                insertarVertice(i);
            }
            for (int i = 1; i < cantVertices; i++)
            {
                int distanciaAleatoria1 = r.Next(1, 25);
                if (i < cantVertices - 1)
                {
                    int distanciaAleatoria2 = r.Next(1, 25);
                    crearArco(i, i + 1, distanciaAleatoria1);
                    crearArco(i, i + 2, distanciaAleatoria2);
                }
                else {
                    crearArco(i, i + 1, distanciaAleatoria1);
                }
            }
        }

        static public void insertarVertice(int numero)
        {
            vertice nuevoVertice = new vertice();
            nuevoVertice.numero = numero;
            if (primerVertice == null)
            {
                primerVertice = nuevoVertice;
            }
            else
            {
                vertice tempV = primerVertice;
                while (tempV.sigV != null)
                {
                    tempV = tempV.sigV;
                }
                tempV.sigV = nuevoVertice;
            }
        }

        static vertice buscarV(int numero) 
        {
            if (primerVertice == null)
                return null;
            vertice tempV = primerVertice;
            while(tempV != null){
                if (tempV.numero == numero)
                    return tempV;
                tempV = tempV.sigV;
            }
        
            return null;
        }

        static public void crearArco(int origen, int destino, int distancia)
        {
            vertice verticeO = buscarV(origen);
            vertice verticeD = buscarV(destino);
            arco nuevoArco = new arco();
            nuevoArco.distancia = distancia;
            nuevoArco.destino = verticeD;

            if (verticeO.sigA == null)
            {
                verticeO.sigA = nuevoArco;
            }
            else
            {
                arco tempA = verticeO.sigA;
                while (tempA.sigA != null)
                {
                    tempA = tempA.sigA;
                }
                tempA.sigA = nuevoArco;
            }
        }

        static public void crearMatriz() 
        {
            matrizValores = new int[cantVertices, cantVertices];
            int columna = 1;
            int fila = 0;
            vertice tempV = primerVertice;
            arco tempA;

            for (int i = 0; i < cantVertices; i++)
            {
                for (int j = 0; j < cantVertices; j++)
                {
                    matrizValores[i,j] = 99999;
                }
            }
            while (tempV != null)
            {
                tempA = tempV.sigA;
                while (tempA != null)
                {
                    matrizValores[fila, columna] = tempA.distancia;
                    columna++;
                    tempA = tempA.sigA;
                }
                columna--;
                fila++;
                tempV = tempV.sigV;
            }
        }

        static public void crearMatrizFloyd() 
        {
            matrizFloyd = matrizValores;
            
            for (int i = 0; i < cantVertices; i++)
            {
                matrizFloyd[i, i] = 0;
            }
        }
    }
}
