using System;
using System.Collections.Generic;
namespace GeneradorDeScanner.Models
{
    
    public class ArbolExpresion
    {

        public string st { get; set; }
        public char Op { get; set; }
        public Stack<string> PilaT { get; set; }
        public Stack<Nodo> PilaS { get; set; }

        

        public ArbolExpresion()
        {
            PilaS = new Stack<Nodo>();
            PilaT = new Stack<string>();
        }

        public void Insertar(string Token, char op)
        {
            if(Token != null)
            {
                Nodo stArbol = new Nodo(Token);
                PilaS.Push(stArbol);
            }
            else if(op != ' ')
            {

            }
        }



    }

}
