using System;
using System.Collections.Generic;
namespace GeneradorDeScanner.Models
{
    
    public class ArbolExpresion 
    {

        public string st { get; set; }
        public char Op { get; set; }
        public Stack<char> PilaT { get; set; }
        public Stack<Nodo> PilaS { get; set; }
        public Dictionary<int , char> Unarios;
        public Dictionary<int, char> NoUnarios;
        public Dictionary<char, int> Operadores;
        public char[] Una;
        public char[] NoUna;
        public char[] Oper;
        public bool ER_mayor;
        public bool ultimo;
        public bool cambio;

        

        public ArbolExpresion()
        {
            PilaS = new Stack<Nodo>();
            PilaT = new Stack<char>();
            Una = new char[3] { '+', '*', '?'};
            NoUna = new char[3] {' ', '|', '·' };
            Oper = new char[11] { '·', '|', '$', '^', '?', '+', '*', '(', ')', '[', ']' };
            Unarios = new Dictionary<int, char>();
            NoUnarios = new Dictionary<int, char>();
            Operadores = new Dictionary<char, int>();
            ultimo = false;
           
            
        }

        public void DiccionarioAe()
        {
            for (int i = 0; i < Oper.Length; i++)
            {
                if (i < Una.Length)
                {
                    Unarios.Add(i, Una[i]);
                    NoUnarios.Add(i, NoUna[i]);
                }
                Operadores.Add(Oper[i], i);
            }
        }

        public void Insertar(string Token, char op, bool Ultimo)
        {

            if (Token != null)
            {
                Nodo stArbol = new Nodo();
                stArbol._key = Token;
                PilaS.Push(stArbol);
            }
            else if (op == '(')
            {
                PilaT.Push(op);
            }

            else if (op == ')')
            {

                if ((PilaT.Count > 0) && (PilaT.Peek() != '('))
                {

                    if ((PilaT.Count > 0) && (PilaS.Count > 2))
                    {

                        Nodo Temp = new Nodo();
                        Temp._key = PilaT.Pop().ToString();
                        ArbolBinario arbol = new ArbolBinario();
                        arbol.Insertar(Temp, 0);
                        arbol.Insertar(PilaS.Pop(), 1);
                        arbol.Insertar(PilaS.Pop(), 2);
                        PilaS.Push(arbol.Retornar());


                    }
                    if (PilaT.Count == 0)
                    {
                        Console.WriteLine("Error, Falta de operandos");
                    }


                }
                else
                {
                    PilaT.Pop();
                }
            }
            else if (Operadores.ContainsKey(op) == true)
            {
                //Son unarios
                if (Unarios.ContainsValue(op) == true)
                {
                    Nodo NodoA = new Nodo();
                    NodoA._key = op.ToString();
                    ArbolBinario arbol = new ArbolBinario();
                    arbol.Insertar(NodoA, 0);
                    if (PilaS.Count < 0)
                    {
                        Console.WriteLine("Error, Falta de operandos");
                    }
                    else
                    {
                        arbol.Insertar(PilaS.Pop(), 2);
                        PilaS.Push(arbol.Retornar());
                    }
                }
                else if (((PilaT.Count != 0) && (PilaT.Peek() != '(') && (Operadores[PilaT.Peek()]) >= Operadores[op]))
                {
                    Nodo NodoB = new Nodo();
                    NodoB._key = PilaT.Pop().ToString();
                    ArbolBinario Temp = new ArbolBinario();
                    //0 raiz, 1 derecho, 2 izquierdo
                    Temp.Insertar(NodoB, 0);
                    if (PilaS.Count < 2)
                    {
                        Console.WriteLine("Error, Falta de operandos");
                    }
                    else
                    {
                        Temp.Insertar(PilaS.Pop(), 1);
                        Temp.Insertar(PilaS.Pop(), 2);
                        PilaS.Push(Temp.Retornar());
                        PilaT.Push(op);

                    }
                }
                else if (NoUnarios.ContainsValue(op) == true)
                {
                    PilaT.Push(op);
                }
            }


           
            else
            {
                Console.WriteLine("Token no reconocido");
            }
            

            while ((PilaT.Count > 0) &&(Ultimo == true))
            {
                if (PilaT.Count > 0)
                {
                    Nodo NodoA = new Nodo();
                    NodoA._key = PilaT.Pop().ToString();
                    ArbolBinario Temp = new ArbolBinario();
                    Temp.Insertar(NodoA, 0);
                    if (Temp.Root._key == "(")
                    {
                        Console.WriteLine("Error por falta de operenados");
                    }
                    if (PilaS.Count < 2)
                    {
                        Console.WriteLine("Error por falta de operenados el tamaño de la PilaS es menor a 2");
                    }
                    else
                    {
                        Temp.Insertar(PilaS.Pop(), 1);
                        Temp.Insertar(PilaS.Pop(), 2);
                        PilaS.Push(Temp.Retornar());
                    }

                  

                }
            }
            if((PilaS.Count != 1) &&(Ultimo == true))
            {
                Console.WriteLine("Error por falta de operandos");
                RetornarIncorrecto(PilaS.Pop());

            }

           
        }

        //Retornar si la longitud de PilaS es diferente de 1
        public Nodo RetornarIncorrecto(Nodo RetornarI)
        {
            return RetornarI;
        }

        public Stack<Nodo> RetornarExpresion()
        {
            return PilaS;
        }

    }

}
