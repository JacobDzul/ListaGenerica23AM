using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lista_Generica    // Se crea un nuevo nodo en la posicion que indicamos, en lugar de reccorer todo, por lo que el que antes era nodo # (ej.2), ahora es un nodo desdpues (ej.3)
{
    class ListaGenrica
    {
        class Nodo
        {
            public int info;
            public Nodo sig;
        }
        private Nodo raiz, fondo;

        public ListaGenrica()
        {
            raiz = null;
        }

        public void Insertar(int posicion, int x)
        {
            if (posicion <= Cantidad() + 1)
            {
                Nodo nuevo = new();
                nuevo.info = x;
                if (posicion <= Cantidad() + 1)
                {
                    Nodo nodo = new();
                    nodo.info = x;

                    if (posicion == 1) // Cuando estamos empezando
                    {
                        nodo.sig = raiz;
                        raiz = nodo;
                    }
                    else if (posicion == Cantidad() + 1)
                    {
                        Nodo reco = raiz;

                        while (reco.sig != null) // Llegar hasta el ultimo numero o hasta que sea diferente a nulo
                        {
                            reco = reco.sig;
                        }
                        reco.sig = nodo;
                        nodo.sig = null;
                    }
                    else
                    {
                        Nodo reco = raiz;       // Crear nuevo nodo apartir de donde estabamos

                        for (int f = 1; f <= posicion - 2; f++)    // E s-2 porque queremos un lugar antes del que estamos seleccioando
                        {
                            reco = reco.sig;
                        }
                        Nodo siguiente = reco.sig;
                        reco.sig = nodo;
                        nodo.sig = siguiente;
                    }

                }
            }
        }

        public int Cantidad()
        {
            int cantidad = 0;
            Nodo reco = raiz;
            while (reco != null)
            {
                reco = reco.sig;
                cantidad++;
            }
            return cantidad;
        }

        public void Imprimir()
        {
            Nodo reco = raiz;

            while (reco != null)
            {
                Console.Write(reco.info + " - ");
                reco = reco.sig;
            }
            Console.WriteLine();
        }
        public int Extraer(int pos)
        {
            if(pos<=Cantidad())
            {
                int informacion;
                if(pos == 1)
                {
                    informacion = raiz.info;
                    raiz=raiz.sig;
                }
                else
                {
                    Nodo reco;
                    reco= raiz;
                    for(int f=1; f<= pos-2; f++)
                    {
                        reco= reco.sig;
                    }
                    Nodo prox=reco.sig;
                    reco.sig= prox.sig;
                    informacion = prox.info;
                }
                return informacion;
            }
            else
            {
                return int.MaxValue;
            }
        }
        public void Intercambiar(int pos1, int pos2)
        {
            if(pos1 <=Cantidad() && pos2<=Cantidad()) 
            {
                Nodo reco1= raiz;
                for(int f = 1; f < pos1; f++)
                {
                    reco1= reco1.sig;
                }
                Nodo reco2= raiz;
                for (int f = 1; f < pos2; f++)
                {
                    reco2 = reco2.sig;
                }
                int aux = reco1.info;
                reco1.info= reco2.info;
                reco2.info=aux;
            }
        }
        public bool Existe(int x)
        {
            Nodo reco= raiz;
            while(reco!= null)
            {
                if (reco.info == x)
                {
                    return true; 
                }
                reco = reco.sig;
            }
            return false;
        }

        static void Main(string[] args)
        {
            ListaGenrica obj = new();
            obj.Insertar(1, 10);
            obj.Insertar(2, 20);
            obj.Insertar(3, 30);
            obj.Insertar(4, 40);
            obj.Insertar(2, 12);

            obj.Imprimir();
            Console.WriteLine("Aplicando el método extraer");
            obj.Extraer(2);
            obj.Imprimir();
            Console.WriteLine("Aplicando el método intercambiar");
            obj.Intercambiar(1, 3);
            obj.Imprimir();
            Console.WriteLine("Aplicando el método Existe");
            if(obj.Existe(11))
            {
                Console.WriteLine("El número 11 se encuentra en la lista");
            }
            else
            {
                Console.WriteLine("No se encuentra;");
            }
            Console.ReadKey();



            //FGDFGDFGDFGDFG
        }
    }
}