using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaLex
{
    class AnalizadorLexico
    {
        private LinkedList<Token> Salida;
        private int estado;
        private String auxlex;

        public LinkedList<Token> escanear(String entrada)
        {
            entrada = entrada + "#";
            Salida = new LinkedList<Token>();
            estado = 0;
            auxlex = "";
            Char c;

            for (int i =0; i <= entrada.Length-1; i++)
            {
                c = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if(Char.IsDigit(c))
                        {
                            estado = 1;
                            auxlex += c;
                        }
                        else if (c.CompareTo('+') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.SIGNO_MAS);
                        }
                        else if (c.CompareTo('-') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.SIGNO_MEN);
                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.SIGNO_POR);
                        }
                        else if (c.CompareTo('/') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.SIGNO_DIV);
                        }
                        else if (c.CompareTo('^') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.SIGNO_POW);
                        }
                        else if (c.CompareTo('(') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.PARENTESIS_IZQ);
                        }
                        else if (c.CompareTo(')') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.PARENTESIS_DER);
                        }
                        else if(c.CompareTo('#')==0 && i == entrada.Length - 1)
                        {
                            Console.WriteLine("Hemos concluido el analisis con exito");
                        }
                        else
                        {
                            Console.WriteLine("Error lexico con:" + c);
                            estado = 0;
                        }
                        break;
                    case 1:
                        if (char.IsDigit(c))
                        {
                            estado = 1;
                            auxlex += c;

                        }else if (c.CompareTo('.') == 0)
                        {
                            estado = 2;
                            auxlex += c;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.NUMERO_ENTERO);
                            i -= 1;
                        }
                            break;
                    case 2:
                        if (char.IsDigit(c))
                        {
                            estado = 3;
                            auxlex += c;
                        }
                        else
                        {
                            Console.WriteLine("Error lexico con:" + c);
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (char.IsDigit(c))
                        {
                            estado = 3;
                            auxlex += c;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.NUMERO_REAL);
                            i -= 1;
                        }
                        break;
                }
            }
            return Salida;

        }

        public void agregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(tipo, auxlex));
            auxlex = "";
            estado = 0;

        }
        public void imprimirListaToken(LinkedList<Token>lista)
        {
            foreach(Token item in lista)
            {
                Console.WriteLine(item.GetTipo() + "<-->" + item.Getval());
            }
        }
    }
}
