using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    public class Program
    {
        static public vertice primerVertice = new vertice();
        static public vertice ultimoVertice = new vertice();

        static public Random r = new Random();
        static public int cantVertices = 10000;
        static public int[,] matrizValores;
        static public int[,] matrizFloyd;

       

        static void Main(string[] args)
        {
            primerVertice = null;
            crearGrafo();
            /*crearMatriz();
            imprimir();
            Dijkstra prueba = new Dijkstra((int)Math.Sqrt(matrizValores.Length), matrizValores);
            prueba.CorrerDijkstra();

            Console.WriteLine("La solucion de la ruta mas corta tomando como nodo inicial el NODO 1 es: ");
            int nodo = 1;
            
            foreach(int i in prueba.D)
            {
                Console.Write("Distancia minima a nodo " + nodo + " es ");
                Console.WriteLine(i);
                nodo++;
            }
            Console.WriteLine( );
            Console.WriteLine("Presione la tecla Enter para salir.");

            crearMatrizFloyd();

            floyd prueba2 = new floyd();
            prueba2.PrintMatrix(prueba2.FloydAlgorithm(matrizFloyd));
            */
            
            rutaCorta(primerVertice, 0);

            Console.WriteLine();

            

            //imprimirVertices();
            Console.ReadKey();
        }

        public class vertice
        {
            public int numero;
            public vertice sigV;
            public arco sigA;
        }

        public class arco
        {
            public int distancia;
            public vertice destino;
            public arco sigA;
            public bool visitado;
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
                ultimoVertice = nuevoVertice;
            }
            else
            {
                vertice tempV = primerVertice;
                while (tempV.sigV != null)
                {
                    tempV = tempV.sigV;
                }
                tempV.sigV = nuevoVertice;
                ultimoVertice = nuevoVertice;
            }
        }

        static public void imprimirVertices()
        {
            vertice tempV = primerVertice;
            while (tempV != null)
            {
                Console.Write(tempV.numero);
                tempV = tempV.sigV;
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

            if (verticeO == null && verticeD == null)
            {
                Console.WriteLine("Un vertice no existe");
            }
            else
            {
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
        }

        static public void imprimir()
        {
            vertice tempV = primerVertice;
            arco tempA;

            while(tempV != null)
            {
                Console.Write("---------------------" + "\r\n");
                Console.Write("Vertice " + tempV.numero + "\r\n");
                tempA = tempV.sigA;
                while(tempA != null)
                {
                    Console.Write("Ruta " + tempA.destino.numero +" distancia " + tempA.distancia + "\r\n");
                    tempA = tempA.sigA;
                }
                tempV = tempV.sigV;
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
                    matrizValores[i,j] = 99;
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
            for (int i = 0; i < cantVertices; i++ )
            {
                for (int j = 0; j < cantVertices; j++)
                {       
                    Console.Write(String.Format("{0,5:0}",matrizValores[i,j]));
                }
                Console.Write("\r\n");
            }
        }

        static public void crearMatrizFloyd() 
        {
            matrizFloyd = matrizValores;
            
            for (int i = 0; i < cantVertices; i++)
            {
                matrizFloyd[i, i] = -1;
            }

        }


        static void rutaCorta(vertice origen, int distanciaTotal)
        {

            if (ultimoVertice == origen)
                return;

            if (origen.sigA.sigA == null)
            {
                Console.WriteLine(distanciaTotal + origen.sigA.distancia);
                //Console.WriteLine("\n" + "Origen: " + origen.numero + " Destino: " + origen.sigA.destino.numero + " Distancia: " + origen.sigA.distancia);
                return;
            }

            if (origen.sigA.distancia < origen.sigA.sigA.distancia)
            {
                //Console.WriteLine("\n" + "Origen: " + origen.numero + " Destino: " + origen.sigA.destino.numero + " Distancia: " + origen.sigA.distancia);
                rutaCorta(origen.sigA.destino, distanciaTotal + origen.sigA.distancia);
            }
            else
            {
                //Console.WriteLine("\n" + "Origen: " + origen.numero + " Destino: " + origen.sigA.sigA.destino.numero + " Distancia: " + origen.sigA.sigA.distancia);
                rutaCorta(origen.sigA.sigA.destino, distanciaTotal + origen.sigA.sigA.distancia);
            }
        }

    }
}
