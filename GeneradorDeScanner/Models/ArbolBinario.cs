using System;
namespace GeneradorDeScanner.Models
{
    
   
    public class Nodo
    {
       
        public string _key { get; set; }
        public Nodo Derecho, Izquierdo;

        public Nodo()
        {
            Derecho = Izquierdo = null;
        }

    }

    public class ArbolBinario
    {

        public Nodo Root { get; set; }
       

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

                Root = new Nodo
                {
                    _key = root._key,
                    Derecho = root.Derecho,
                    Izquierdo = root.Izquierdo
                };
                
                direccion = 0;
                return Root;
                
            }
            

            else if(direccion == 1)
            {
                Root.Derecho = Recursivo(Root.Derecho, 1, root);
                
            }
            else if(direccion == 2)
            {
                Root.Izquierdo = Recursivo(Root.Izquierdo, 2, root);
                
            }

            return Root;
        }

        public Nodo Retornar()
        {
            return Root;
        }

        


    }
}
