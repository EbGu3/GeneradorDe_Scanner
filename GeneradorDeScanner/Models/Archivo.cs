using System;
using System.IO;
using System.Collections.Generic;
namespace GeneradorDeScanner.Models
{
    public class Archivo
    {
        Dictionary<int, char> Mayusculas;
        Dictionary<int, char> Minusculas;
        Dictionary<int, char> Operadores;
        Dictionary<int, char> Numeros;
        Dictionary<int, char> Otros;

        
        char[] My;
        char[] Mi;
        char[] oper;
        char[] N1;
        char[] N2;
        char[] N3;
        char[] N4;
        char[] Others;
        string Ruta;
        bool Ultimo;
        public ArbolExpresion _arbolExpresion;

        public Archivo(string ruta)
        {
            My = new char[27] { 'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Mi = new char[27] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            oper = new char[11] { '[', ']', '(', ')', '*', '+', '?', '^', '$', '|', '·'};
            N1 = new char[3] { '0', '1', '2' };
            N2 = new char[6] { '0', '1', '2', '4', '5', '6' };
            N3 = new char[4] { '0', '1', '2', '4' };
            N4 = new char[9] { '0', '1', '2', '4', '5', '6', '7', '8', '9' };
            Others = new char[6] { '_', '\\' , ' ', '=', '\n', '#'};
            Ruta = ruta;
            Ultimo = false;
            _arbolExpresion = new ArbolExpresion();

            Mayusculas = new Dictionary<int, char>();
            Minusculas = new Dictionary<int, char>();
            Operadores = new Dictionary<int, char>();
            Numeros = new Dictionary<int, char>();
            Otros = new Dictionary<int, char>();
        }

        public void Lectura()
        {
            try
            {
                using (var FileStream = new FileStream(Ruta, FileMode.Open))
                {
                    using (var StreamReader = new StreamReader(FileStream))
                    {
                        Console.WriteLine("Se ingreso el archivo");

                        var Posicion = 0;
                        var LineaRegistrada = new string[1];
                        var Datosleidos = "";

                        Datosleidos = StreamReader.ReadLine();
                        LineaRegistrada = Datosleidos.Split(' ');

                        while (Datosleidos != null)
                        {
                            if (Posicion < LineaRegistrada.Length)
                            {
                                if (LineaRegistrada[Posicion].ToString() == "SETS")
                                {
                                    Console.WriteLine("Este archivo contiene sets");
                                    Console.WriteLine(LineaRegistrada[Posicion].ToString());

                                    Datosleidos = StreamReader.ReadLine();

                                }
                                else
                                {

                                    Console.WriteLine(LineaRegistrada[Posicion].ToString());
                                    Datosleidos = StreamReader.ReadLine();

                                }
                                Posicion++;

                            }
                            Posicion = 0;
                            LineaRegistrada[Posicion] = Datosleidos;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No ingreso correctamente el archivo");
            }
            
        }


        public void Diccinarios()
        {

            for (int i = 0; i < My.Length; i++)
            {
                Mayusculas.Add(i,My[i]);
                Minusculas.Add(i, Mi[i]);

                if(i < oper.Length)
                {
                    Operadores.Add(i, oper[i]);
                }
                if(i < N4.Length)
                {
                    Numeros.Add(i, N4[i]);
                }
                if(i < Others.Length)
                {
                    Otros.Add(i, Others[i]);
                }

            }
        }

        public void LecturaER()
        {
            //var ERS = "[[(SETS)·(\n+)·( +)][·(\n+)·( +)][·(id)·( +)·=·( +)][·(‘·My·‘+)·\\+·(‘·Mi·‘+)·\\+·(‘·Others·‘)][|(‘·My·‘+)·\\+·(‘·Mi·‘+)][|((‘·N4·‘+)][|(‘·N4·‘+)·\\+·(‘·Mi·‘+)][|(‘·N4·‘+)·\\+·(‘·My·‘+)][|(CHR·\\(·(N1?)·N2·N3·\\))+)]+]?]·#";
            //var ERS = "[[[(SETS)·(\n+)·( *)][·(\n)·(+)·(id)·n( +)·=·( +)][·(‘·My·‘+)·\\+·(‘·Mi·‘+)·\\+·(‘·N4·‘)|(‘·My·‘+)·\\+·(‘·Mi·‘+)|((‘·N4·‘+)|(‘·N4·‘+)·\\+·(‘·Mi·‘+)|(‘·N4·‘+)·\\+·(‘·My·‘+)|(CHR·\\(·(N1?)·N2·N3·\\)+)]·+]·?]·#";

            //var ERS = "((((SETS)·(\n+)·(*))(((·\n· +·id· +·=· +)(·(‘·My·‘+)·\\+·(‘·Mi·‘+)·\\+·(‘·_·‘)|(‘·My·‘+)·\\+·(‘·Mi·‘+)|(‘·N4·‘+)·\\+·(‘·Mi·‘+)|(‘·N4·‘+)|(CHR·\\(·(N1?)·N2·N3·\\))+)·+))·?)·#";

            var ERS = "(s.(e.i.(v|p|m|c)+)+)?.t.(u.n.i.(e|m|v|1|2|3|4|r)+)+.a.r.1.2.3.(n.i.v)+.4.(e.1.2.3.(n.i.v)+.4)*.(q.i.n)+";
;
            string[] LineaLeida = new string[1];
            char[] spl = new char[2] { '[', ']' };
            LineaLeida = ERS.Split(spl);
            bool EsOp = true;
            var i = 0;
            var o = 0;
            var c = 0;
            var o1 = 0;
            var c1 = 0;
            string Palabra = "";
            //AñadirOperandos al Diccionarioi
            _arbolExpresion.DiccionarioAe();
            
            //Cambiar Linea
            while (i < LineaLeida.Length)
            {

                if (LineaLeida[i] != "")
                {
                     char[] a = new char[LineaLeida[i].Length];
                     a = (LineaLeida[i]).ToCharArray();

                    //Buscar Si existe el operador
                    while (c1 <= a.Length)

                    {
                        
                        if(c1 == a.Length || a.Length == 1)
                        {
                            Ultimo = true;
                        }
                        


                        if(Palabra == "\\" | Palabra == " ")
                        {
                            EsOp = false;
                        }
                        if ((o1 < a.Length - 1) && ((Operadores.ContainsValue(a[o1]) == true) && (EsOp == true)))
                        {
                            _arbolExpresion.Insertar(null, a[o1], Ultimo);
                            EsOp = false;
                            c1 = o1 + 1;
                        }
                        if ((c1 < a.Length) && ((Mayusculas.ContainsValue(a[c1]) == true | Minusculas.ContainsValue(a[c1]) == true | Numeros.ContainsValue(a[c1]) == true | Otros.ContainsValue(a[c1]) == true)))
                        {
                            Palabra += a[c1];
                            if (Palabra == "SETS" | Palabra == "N1" | Palabra == "N2" | Palabra == "N3" | Palabra == "N4" | Palabra == "CHR" || Palabra == "id") 
                            {
                                _arbolExpresion.Insertar(Palabra, ' ',Ultimo);
                                EsOp = true;
                                o1 = c1+1;
                                Palabra = "";
                            }
                            else if(Palabra == "\n" | Palabra == "\\+" | Palabra == "\\(" | Palabra == "\\)" | Palabra == "+" )
                            {
                                string[] Separar = new string[1];

                                if(Palabra == "\n")
                                {
                                    _arbolExpresion.Insertar(Palabra, ' ', Ultimo);
                                    EsOp = false;
                                    Palabra = "";
                                }
                                else if(Palabra == "\\+")
                                {
                                    _arbolExpresion.Insertar(Palabra, ' ', Ultimo);
                                    EsOp = false;
                                    Palabra = "";

                                }
                                else
                                {
                                    Separar = Palabra.Split('\\');
                                    Palabra = Separar.ToString();
                                    _arbolExpresion.Insertar(Palabra, ' ', Ultimo);
                                    Palabra = "";
                                    
                                   
                                   
                                }
                                
                            }
                            else if(Otros.ContainsValue(a[c1]) == true)
                            {
                                _arbolExpresion.Insertar(Palabra, ' ', Ultimo);
                          
                                o1 = c1 +1;
                                EsOp = true;

                                Palabra = "";

                            }
                           

                        }
                        else if((o1 < a.Length - 1) && (Operadores.ContainsValue(a[o1]) == true))
                        {
                            EsOp = true;
                            o1 = c1;
                        }
                        c1++;
                    }

                    Ultimo = false;
                    c1 = 0;
                    o1 = 0;
                   
                }
                i++;


            }


            _arbolExpresion.RetornarExpresion();







        }
    }
}
