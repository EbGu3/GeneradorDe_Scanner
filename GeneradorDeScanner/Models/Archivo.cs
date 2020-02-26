using System;
using System.IO;
namespace GeneradorDeScanner.Models
{
    public class Archivo
    {
        char[] My;
        char[] Mi;
        char[] oper;
        char[] N1;
        char[] N2;
        char[] N3;
        char[] N4;
        string Ruta;
        public ArbolExpresion _arbolExpresion;

        public Archivo(string ruta)
        {
            My = new char[27] { 'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            My = new char[27] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            My = new char[11] {'\\', '[', ']', '(', ')', '*', '+', '?', '^', '$', '|'};
            N1 = new char[3] { '0', '1', '2' };
            N2 = new char[6] { '0', '1', '2', '4', '5', '6' };
            N3 = new char[4] { '0', '1', '2', '4' };
            N4 = new char[9] { '0', '1', '2', '4', '5', '6', '7', '8', '9' };
            Ruta = ruta;
            _arbolExpresion = new ArbolExpresion();
        }

        public void Lectura()
        {
            using (var FileStream = new FileStream(Ruta, FileMode.Open))
            {
                using(var StreamReader = new StreamReader(FileStream))
                {
                    Console.WriteLine("Se ingreso el archivo");


                    var LineaRegistrada = new string[1];
                    var Datosleidos = "";

                    Datosleidos = StreamReader.ReadLine();
                    LineaRegistrada = Datosleidos.Split(' ');

                    while(Datosleidos != null)
                    {
                        if(LineaRegistrada[0].ToString() == "SETS")
                        {
                            Console.WriteLine("Este archivo contiene sets");

                            _arbolExpresion.Insertar(LineaRegistrada[0], ' ');
                            Datosleidos = StreamReader.ReadLine();
                            
                        }
                        else
                        {
                            Console.WriteLine("No contiene sets");
                        }
                    }
                    
                 


                }
            }
        }


    }
}
