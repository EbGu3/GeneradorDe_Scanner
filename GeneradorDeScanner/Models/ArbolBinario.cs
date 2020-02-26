using System;
namespace GeneradorDeScanner.Models
{
    public class Nodo
    {
        public string Key { get; set; }
        public Nodo Derecho, Izquierdo;

        public Nodo(string key)
        {
            Key = key;
            Derecho = Izquierdo = null;
        }

    }

    public class ArbolBinario
    {

        public Nodo Root { get; set; }
        public bool Insertado= false; 

        public ArbolBinario()
        {
            Root = null;
        }

        public void Insertar(Nodo root, int Direccion)
        {
            Root = Recursivo(Root, Direccion, root);
        }

        Nodo Recursivo(Nodo Root, int direccion, Nodo root)
        {
            if(Root == null)
            {
                Root = new Nodo(root.Key);
                direccion = 0;
                return Root;
                
            }

            else if(direccion == 1)
            {
                Root.Derecho = Recursivo(Root.Derecho, 1, root);
                Insertado = false;
            }
            else if(direccion == 2)
            {
                Root.Izquierdo = Recursivo(Root.Izquierdo, 2, root);
                Insertado = false;
            }

            return Root;
        }




    }
}
