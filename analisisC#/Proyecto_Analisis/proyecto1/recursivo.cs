using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace proyecto1
{
    class recursivo
    {
        public int distanciaCorta = 99999;
        public Int64 comparacionesR = 0;
        public Int64 asignacionesR = 0;
        public Int64 cantLineasR = 0;
        public Stack pila = new Stack();
        public string ruta = "";

        public recursivo()
        {
            
        }

        public void rutaCorta(vertice tempVertice, int distancia, string ruta1 )
        {
            string ruta2 = ruta1 + tempVertice.numero + ", ";                                           cantLineasR++; comparacionesR++;
            if (distancia > distanciaCorta)
            {
                cantLineasR++;
                return;
            }
                                                                                                        cantLineasR++; comparacionesR++;
            if (tempVertice.sigV == null)
            {
                ruta = ruta2;
                distanciaCorta = distancia;                                                             asignacionesR++;
                return;
            }
                                                                                                        cantLineasR++; comparacionesR++;
            if (tempVertice.sigV.sigV == null)
            {
                                                                                                        cantLineasR += 2;
                rutaCorta(tempVertice.sigV, (distancia + tempVertice.sigA.distancia), ruta2);                  asignacionesR++;
                return;
            }
                                                                                                        cantLineasR += 2; asignacionesR += 2;
            rutaCorta(tempVertice.sigV, distancia + tempVertice.sigA.distancia, ruta2);
            rutaCorta(tempVertice.sigV.sigV, distancia + tempVertice.sigA.sigA.distancia, ruta2);
        }
    }
}